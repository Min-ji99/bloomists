using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_way : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWayPointIndex = 0;
    private float minDistance = 0.05f;
    private int lastWaypointIndex;

    private float movementSpeed = 0.1f;
    private float rotationSpeed = 1f;

    private bool elfMove = true;

    public bool seedend = false;

    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWayPointIndex];
    }

    void Update()
    {
        if(seedend == false)
        {
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

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if(currentDistance <= minDistance)
        {
            targetWayPointIndex++;
            UpdateTargetWaypoint();
        }
        //if (currentDistance <= minDistance && elfMove == true)
        //{
        //    targetWayPointIndex++;
        //    if (targetWayPointIndex == lastWaypointIndex)
        //    {
        //        elfMove = false;
        //    }
        //    //UpdateTargetWaypoint();
        //    //Debug.Log("증가 " + targetWayPointIndex);
        //}
        //else if (currentDistance <= minDistance && elfMove == false)
        //{
        //    targetWayPointIndex--;
        //    //Debug.Log("감소 " + targetWayPointIndex);
        //    if (targetWayPointIndex == 0)
        //    {
        //        elfMove = true;
        //    }

        //}

    }

    void UpdateTargetWaypoint()
    {
        //if(targetWayPointIndex > lastWaypointIndex)
        //{
        //    targetWayPointIndex = 0;
        //}

        targetWaypoint = waypoints[targetWayPointIndex];

        if (targetWayPointIndex > lastWaypointIndex)
            seedend = true;
    }

}
