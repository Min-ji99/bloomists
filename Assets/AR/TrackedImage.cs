using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

//[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImage : MonoBehaviour
{
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
    //    [SerializeField]
    //    private GameObject placeblePrefab;

    //    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    //    private ARTrackedImageManager trackedImageManager;

    //    private int count = 0;
    //    이미지 추적은 처음 화면 켜지고 그 위치를(0, 0, 0)으로 받아들임
    //    그러니까 마커의 위치를 받아서 그 위치로 전달을 해주어야함

    //    private void Awake()
    //    {
    //        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();


    //    }

    //    private void OnEnable()
    //    {
    //        trackedImageManager.trackedImagesChanged += ImageChanged;
    //    }
    //    private void OnDisable()
    //    {
    //        trackedImageManager.trackedImagesChanged -= ImageChanged;
    //    }
    //    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    //    {
    //        foreach (ARTrackedImage trackedImage in eventArgs.added)
    //        {
    //            UpdateImage(trackedImage);
    //        }
    //        foreach (ARTrackedImage trackedImage in eventArgs.updated)
    //        {
    //            UpdateImage(trackedImage);
    //        }
    //        foreach (ARTrackedImage trackedImage in eventArgs.removed)
    //        {
    //            spawnedPrefabs[trackedImage.name].SetActive(false);
    //        }
    //    }
    //    private void UpdateImage(ARTrackedImage trackedImage)
    //    {
    //        string name = trackedImage.referenceImage.name;
    //        Vector3 position = trackedImage.transform.position;

    //        GameObject prefab = spawnedPrefabs[name];
    //        prefab.transform.position = position;
    //        Instantiate(placeblePrefab, position, Quaternion.identity);
    //        foreach (GameObject prefab in placeblePrefab)
    //        {
    //            GameObject newPrefab = Instantiate(prefab, position, Quaternion.identity);
    //            newPrefab.name = prefab.name;
    //            spawnedPrefabs.Add(prefab.name, newPrefab);
    //            count++;
    //        }
    //        prefab.SetActive(true);
    //        foreach (GameObject go in spawnedPrefabs.Values)
    //        {
    //            if (go.name != name)
    //            {
    //                go.SetActive(false);
    //            }
    //        }
    //    }
}
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.ARFoundation;

//public class MultiImageTracker : MonoBehaviour
//{
//    private ARTrackedImageManager m_trackedImageManager;

//    [SerializeField]
//    private TrackedPrefab[] prefabToInstantiate;

//    private Dictionary<string, GameObject> instanciatePrefab;

//    private void Awake()
//    {
//        m_trackedImageManager = GetComponent<ARTrackedImageManager>();
//        instanciatePrefab = new Dictionary<string, GameObject>();
//    }

//    private void OnEnable()
//    {
//        m_trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
//    }

//    private void OnDisable()
//    {
//        m_trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
//    }

//    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
//    {
//        foreach (ARTrackedImage addedImage in eventArgs.added)
//        {
//            InstantiateGameObject(addedImage);
//        }

//        foreach (ARTrackedImage updatedImage in eventArgs.updated)
//        {
//            if (updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
//            {
//                UpdateTrackingGameObject(updatedImage);
//            }
//            else if (updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
//            {
//                UpdateLimitedGameObject(updatedImage);
//            }
//            else
//            {
//                UpdateNoneGameObject(updatedImage);
//            }
//        }

//        foreach (ARTrackedImage removedImage in eventArgs.removed)
//        {
//            DestroyGameObject(removedImage);
//        }
//    }

//    private void InstantiateGameObject(ARTrackedImage addedImage)
//    {
//        for (int i = 0; i < prefabToInstantiate.Length; i++)
//        {
//            if (addedImage.referenceImage.name == prefabToInstantiate[i].name)
//            {
//                GameObject prefab = Instantiate<GameObject>(prefabToInstantiate[i].prefab, transform.parent);
//                prefab.transform.position = addedImage.transform.position;
//                prefab.transform.rotation = addedImage.transform.rotation;

//                instanciatePrefab.Add(addedImage.referenceImage.name, prefab);
//            }
//        }
//    }

//    private void UpdateTrackingGameObject(ARTrackedImage updatedImage)
//    {

//        for (int i = 0; i < instanciatePrefab.Count; i++)
//        {
//            if (instanciatePrefab.TryGetValue(updatedImage.referenceImage.name, out GameObject prefab))
//            {
//                prefab.transform.position = updatedImage.transform.position;
//                prefab.transform.rotation = updatedImage.transform.rotation;
//                prefab.SetActive(true);
//            }
//        }
//    }

//    private void UpdateLimitedGameObject(ARTrackedImage updatedImage)
//    {
//        for (int i = 0; i < instanciatePrefab.Count; i++)
//        {
//            if (instanciatePrefab.TryGetValue(updatedImage.referenceImage.name, out GameObject prefab))
//            {
//                if (!prefab.GetComponent<ARTrackedImage>().destroyOnRemoval)
//                {
//                    prefab.transform.position = updatedImage.transform.position;
//                    prefab.transform.rotation = updatedImage.transform.rotation;
//                    prefab.SetActive(true);
//                }
//                else
//                {
//                    prefab.SetActive(false);
//                }

//            }
//        }
//    }

//    private void UpdateNoneGameObject(ARTrackedImage updateImage)
//    {
//        for (int i = 0; i < instanciatePrefab.Count; i++)
//        {
//            if (instanciatePrefab.TryGetValue(updateImage.referenceImage.name, out GameObject prefab))
//            {
//                prefab.SetActive(false);
//            }
//        }
//    }

//    private void DestroyGameObject(ARTrackedImage removedImage)
//    {
//        for (int i = 0; i < instanciatePrefab.Count; i++)
//        {
//            if (instanciatePrefab.TryGetValue(removedImage.referenceImage.name, out GameObject prefab))
//            {
//                instanciatePrefab.Remove(removedImage.referenceImage.name);
//                Destroy(prefab);
//            }
//        }
//    }
//}

//[System.Serializable]
//public struct TrackedPrefab
//{
//    public string name;
//    public GameObject prefab;
//}