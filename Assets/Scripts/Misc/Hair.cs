using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    [Header("Length")]
    public int length;
    public LineRenderer lineRed;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    [Header("Target & Speed")]
    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    [Header("Wiggle")]
    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    private void Start()
    {
        lineRed.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i / trailSpeed);
        }
        lineRed.SetPositions(segmentPoses);
    }
}
