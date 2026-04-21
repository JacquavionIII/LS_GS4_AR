using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class UIandSound : MonoBehaviour
{
    public AudioClip UIClick;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Vector2.zero;
        bool isPressed = false;

        // Check for touch input on mobile
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            isPressed = true;
        }
        // Fall back to mouse input
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            screenPosition = Mouse.current.position.ReadValue();
            isPressed = true;
        }

        if (isPressed)
        {
            Debug.Log("Pressed primary button.");

            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Camlann")
                {
                    audioSource.PlayOneShot(UIClick, 0.75f);
                }

                if (hit.transform.tag == "Freteval")
                {
                    audioSource.PlayOneShot(UIClick, 0.75f);
                }

                if (hit.transform.tag == "Massacre")
                {
                    audioSource.PlayOneShot(UIClick, 0.75f);
                }

                if (hit.transform.tag == "Time Period")
                {
                    audioSource.PlayOneShot(UIClick, 0.75f);
                }

                if (hit.transform.tag == "King Richard")
                {
                    audioSource.PlayOneShot(UIClick, 0.75f);
                }
            }
        }
    }
}
