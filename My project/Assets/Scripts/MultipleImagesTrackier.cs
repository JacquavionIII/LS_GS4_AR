using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultipleImagesTrackier : MonoBehaviour
{
   //Prefabs we want to spawn
   [SerializeField] List<GameObject> prefabsToSpawn = new List<GameObject>();

   // ARTrackedImageManager reference
   private ARTrackedImageManager _trackedImageManager;

   //Dictionary to reference spawned prefabs with tracked image name
   private Dictionary<string, GameObject> _arObjects;

   //Initialization and references assigning
   private void Start()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        if ( _trackedImageManager == null) return;
        _trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
        _arObjects = new Dictionary<string, GameObject>();
        SetupSceneElements();
    }

    private void OnDestroy()
    {
        _trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
    }

    //Setup Scene Elements
    private void SetupSceneElements()
    {
        foreach (var prefab in prefabsToSpawn)
        {
            var arObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            arObject.name = prefab.name;
            arObject.gameObject.SetActive(false);
            _arObjects.Add(arObject.name, arObject);
        }
    }

    //Update tracked images and prefabs
    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            UpdateTrackedImages(trackedImage);
        }
        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateTrackedImages(trackedImage);
        }
        foreach (var trackedImage in eventArgs.removed)
        {
            UpdateTrackedImages(trackedImage.Value);
        }
    }

    private void UpdateTrackedImages(ARTrackedImage trackedImage)
    {
        if(trackedImage == null) return;
        if(trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            _arObjects[trackedImage.referenceImage.name].gameObject.SetActive(false);
            return;
        }

        _arObjects[trackedImage.referenceImage.name].gameObject.SetActive(true);
        _arObjects[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
        _arObjects[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
    } 

}
