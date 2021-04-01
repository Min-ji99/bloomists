using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Roller : MonoBehaviour {

	//tangent speed at any point along roller
	public float tangentSpeed;
	//radius of the roller
	public float radius= 0.125f;

	private Rigidbody rb;

	
	Plant02 p2;
	AfterIce aI;
	Seedposition Sp;
	rotate ro;

	void Start() {

		p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
		aI = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<AfterIce>();
		Sp= GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
		ro = GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();

		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = true;
	}
	// Update is called once per frame
	void Update () {
        //rotate the roller

        if (p2.appear==true||Sp.state==true)
        {
			tangentSpeed = 0;
			
        }
        if (aI.bloom==true||ro.isMove==true)
        {
			tangentSpeed = 1;
		}

		float angularVelocity = (tangentSpeed*Mathf.Rad2Deg) / radius;
		Quaternion newRot = rb.rotation * Quaternion.AngleAxis (angularVelocity * Time.deltaTime, transform.InverseTransformDirection(transform.right));
		rb.MoveRotation (newRot);
	}
}
