using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform positionA, positionB;
    public float speed;
    Vector3 targetPosition;

    private void Start()
    {
        targetPosition = positionB.position;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, positionA.position) < 0.05f)
        {
            targetPosition = positionB.position;
        }

        if(Vector2.Distance(transform.position, positionB.position) < 0.05f)
        {
            targetPosition = positionA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
    
    //for debug visualization
    private void OnDrawGizmos()
    {
        if(gameObject != null && positionA != null && positionB != null)
        {
            Gizmos.DrawLine(gameObject.transform.position, positionA.position);
            Gizmos.DrawLine(gameObject.transform.position, positionB.position);
        }
    }
}
