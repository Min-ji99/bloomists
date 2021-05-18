using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImage : MonoBehaviour
{
    /*
    private ARTrackedImageManager trackedImageManager;
    private ARTrackedImage Image;

    private void Awake()
    {
        //trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    public void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }
    public void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
    public void OnImageChanged(ARTrackedImagesChangedEventArgs eventargs)
    {
        foreach (var trackedImage in eventargs.added)
        {

            trackedImage.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            trackedImage.transform.localPosition = new Vector3(Image.extents.x, Image.extents.y, 0);
        }
    }
    */
    //움직임에 따라 이동
    
    [SerializeField]
    private GameObject[] arObjectToPlace;

    [SerializeField]
    private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    private ARTrackedImageManager trackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    public GameObject arCamera;
    private Vector3 trackedCameraPosition;

    public bool ar=false;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject arObject in arObjectToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }
    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        AssignGameObjecct(trackedImage.referenceImage.name, trackedImage.transform.position, trackedImage.transform.rotation);
        //AssignGameObjecct(trackedImage.referenceImage.name, trackedImage.transform.position);
        ar = true;
    }
    
    void AssignGameObjecct(string name, Vector3 newPosition)
    {
        if (arObjectToPlace != null)
        {
            //arObjects[name].SetActive(true);
            //arObjects[name].transform.position = newPosition - distance;
            //arObjects[name].transform.localScale = scaleFactor;

            if (name != "seedFactory 1")
            {
                Vector3 LimitedPosition = arCamera.transform.position;
                arObjects[name].transform.position -= LimitedPosition - trackedCameraPosition;
            }
            else
            {
                trackedCameraPosition = arCamera.transform.position;

                arObjects[name].SetActive(true);
                arObjects[name].transform.position = newPosition;
                arObjects[name].transform.localScale = scaleFactor;
            }
            foreach (GameObject go in arObjects.Values)
            {
                if (go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }
    
    void AssignGameObjecct(string name, Vector3 newPosition, Quaternion newRotation)
    {
        if (arObjectToPlace != null)
        {
            
            if (name!= "seedFactory 1")
            {
                Vector3 LimitedPosition = arCamera.transform.position;
                arObjects[name].transform.position -= LimitedPosition - trackedCameraPosition;
            }
            else
            {
                trackedCameraPosition = arCamera.transform.position;
                arObjects[name].SetActive(true);
                arObjects[name].transform.position = newPosition;
                arObjects[name].transform.rotation = newRotation;
                arObjects[name].transform.localScale = scaleFactor;
            }
    
            foreach (GameObject go in arObjects.Values)
            {
                if (go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }
}