using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosition, yPosition;
    public GameObject mainCamera;
    public float parallaxEffectAmount; //0 means not moving, 1 is perfectly following the camera
    
    void Start()
    {
        startPosition = transform.position.x;
        yPosition = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x; //this background's length
    }

    void Update()
    {
        float movePosition = (mainCamera.transform.position.x * (1 - parallaxEffectAmount)); //how far have the player moved relative to the camera
        float distance = (mainCamera.transform.position.x * parallaxEffectAmount);
        float yDistance = (mainCamera.transform.position.y * parallaxEffectAmount);

        transform.position = new Vector3(startPosition + distance, yPosition + yDistance, transform.position.z);

        //move the background following the camera
        if(movePosition > startPosition + length)
        {
            startPosition += length;
        }
        else if(movePosition < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
