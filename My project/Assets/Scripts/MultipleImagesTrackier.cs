using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystem;

public class MultipleImagesTrackier : MonoBehaviour
{
   //Prefabs we want to spawn
   [SerializedField] List<GameObject> prefabsToSpawn = new List<GameObject>();

   // ARTrackedImageManager reference
   private ARTrackedImageManager _trackedImageManager;

   //Dictionary to reference spawned prefabs with tracked image name
   private Dictionary<string, GameObject> _arObjects;

   //Initialization and references assigning

}
