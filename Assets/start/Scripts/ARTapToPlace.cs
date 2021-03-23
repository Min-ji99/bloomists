using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private ARRaycastManager arManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool createFactory = false;

    void Start()
    {
        arManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if(createFactory == false)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                PlaceObject();
                createFactory = true;
            }
        }
        if (createFactory)
        {
            Destroy(placementIndicator);
        }
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        //var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            /*
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
            */
        }
    }

}