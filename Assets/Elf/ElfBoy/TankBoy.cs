using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBoy : MonoBehaviour
{

    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;

    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWayPointIndex = 0;
    private float minDistance = 0.001f;
    private int lastWaypointIndex;

    private float movementSpeed = 0.1f;
    private float rotationSpeed = 0.5f;


    void Start()
    {
        animator = GetComponent<Animator>();

        //lastWaypointIndex = waypoints.Count - 1;
        //targetWaypoint = waypoints[targetWayPointIndex];
    }

    void Update()
    {
        animator.SetBool("Click", false);
        touchClick();

        if (isMove==true) 
        {
            animator.SetBool("Click", true);

            float movementStep = movementSpeed * Time.deltaTime;
            float rotationStep = rotationSpeed * Time.deltaTime;

            Vector3 directionToTarget = targetWaypoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);


            transform.rotation = rotationToTarget;

            float distance = Vector3.Distance(transform.position, targetWaypoint.position);
            CheckDistanceToWaypoint(distance);

            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
        }

    }

    void touchClick()
    {
        // 터치 입력이 들어올 경우
        if (Input.GetMouseButtonDown(0))
        {
            // 오브젝트 정보를 담을 변수 생성 
            RaycastHit hit;
            // 터치 좌표를 담는 변수 
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 터치한 곳에 ray를 보냄 
            Physics.Raycast(touchray, out hit); // ray가 오브젝트에 부딪힐 경우 

            if (hit.collider.gameObject.name == "02_tank"|| hit.collider.gameObject.name == "Torus013") 
            {
                if (isMove == false)
                {
                    isMove = true;
                    animator.SetBool("Click", true);

                    lastWaypointIndex = waypoints.Count - 1;
                    targetWaypoint = waypoints[targetWayPointIndex];
                   
                }
                //else
                //{
                //    isMove = false;
                //    animator.SetBool("Click", false);
                //}

                Debug.Log(hit.collider.gameObject.name);

            }

        }



    }
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWayPointIndex++;
           UpdateTargetWaypoint();
          
        }



    }

    void UpdateTargetWaypoint()
    {
        if (targetWayPointIndex > lastWaypointIndex)
        {
            animator.SetBool("Click", false);
            isMove = false;

        }
        targetWaypoint = waypoints[targetWayPointIndex];
    }

}
