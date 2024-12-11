using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutSpotController : MonoBehaviour
{
    private Camera mainCamera;
    private CameraMove mainCameraScript;

    private void Start()
    {
        mainCameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            mainCameraScript.ZoomOut();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            mainCameraScript.ZoomIn();
        }
    }
}
