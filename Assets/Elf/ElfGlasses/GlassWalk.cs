﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWalk : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWayPointIndex = 0;
    private float minDistance = 0.01f;
    private int lastWaypointIndex;

    private float movementSpeed = 0.05f;
    private float rotationSpeed = 1f;

    private bool elfMove = true;

    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWayPointIndex];
    }

    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);


        transform.rotation = rotationToTarget;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);


    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance && elfMove == true)
        {
            targetWayPointIndex++;
            if (targetWayPointIndex == lastWaypointIndex)
            {
                elfMove = false;
            }
            //UpdateTargetWaypoint();
            //Debug.Log("증가 " + targetWayPointIndex);
        }
        else if (currentDistance <= minDistance && elfMove == false)
        {
            targetWayPointIndex--;
            //Debug.Log("감소 " + targetWayPointIndex);
            if (targetWayPointIndex == 0)
            {
                elfMove = true;
            }

        }
        targetWaypoint = waypoints[targetWayPointIndex];
    }
}