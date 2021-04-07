using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Roller : MonoBehaviour {

	//tangent speed at any point along roller
	public float tangentSpeed;
	//radius of the roller
	public float radius = 0.125f;

	private Rigidbody rb;


	Plant02 p2;
	AfterIce aI;
	Seedposition Sp;
	rotate ro;
	Plant01 p1;
	Flower01 f1;
	Flower2 f2;
	Fruit01 f01;
	Fruit02 f02;

	void Start()
	{

		p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
		aI = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<AfterIce>();
		Sp = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
		ro = GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();
		p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
		f1 = GameObject.Find("Flower1").GetComponent<Flower01>();
		f2 = GameObject.Find("Flower2").GetComponent<Flower2>();
		f01 = GameObject.Find("Fruit1").GetComponent<Fruit01>();
		f02 = GameObject.Find("Fruit2").GetComponent<Fruit02>();

		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}
	// Update is called once per frame
	void Update()
	{
		//rotate the roller

		if (Sp.state == true || Sp.appear == true || p1.appear == true || p2.reach == true)
		{
			//Debug.Log("Sp.appear:" + Sp.appear);
			tangentSpeed = 0;

		}
		else if (aI.bloom == true || ro.isMove == true || p1.bloom == true || f1.state == true || f2.state == true || f01.state == true || f02.state == true)
		{
			//Debug.Log("p2.reach:" + p2.reach);
			tangentSpeed = 1;
		}
		

		float angularVelocity = (tangentSpeed * Mathf.Rad2Deg) / radius;
		Quaternion newRot = rb.rotation * Quaternion.AngleAxis(angularVelocity * Time.deltaTime, transform.InverseTransformDirection(transform.right));
		rb.MoveRotation(newRot);
	}
}
