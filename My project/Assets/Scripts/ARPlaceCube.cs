using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class ARPlaceCube : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    bool isPlacing = false;

    // Update is called once per frame
    void Update()
    {
        if (!raycastManager) return;

        if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
        {
            var touch = Touchscreen.current.touches[0];
            if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began && !isPlacing)
            {
                isPlacing = true;
                PlaceObject(touch.position.ReadValue());
                StartCoroutine(SetIsPlacingToFalseWithDelay());
            }
        }

        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame && !isPlacing)
        {
            isPlacing = true;
            PlaceObject(Mouse.current.position.ReadValue());
            StartCoroutine(SetIsPlacingToFalseWithDelay());      
        }
    }

    void PlaceObject(Vector2 touchPosition)
    {
        var rayhits = new List<ARRaycastHit>();
        raycastManager.Raycast(touchPosition, rayhits, TrackableType.AllTypes);

        if (rayhits.Count > 0)
        {
            Vector3 hitPosition = rayhits[0].pose.position;
            Quaternion hitPoseRotation = rayhits[0].pose.rotation;
            Instantiate(raycastManager.raycastPrefab, hitPosition, hitPoseRotation);
        }
    }

    IEnumerator SetIsPlacingToFalseWithDelay()
    {
        yield return new WaitForSeconds(0.25f);
        isPlacing = false;
    }
}
