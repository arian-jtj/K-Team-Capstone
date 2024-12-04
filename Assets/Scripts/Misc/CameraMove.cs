using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera _mainCamera;
    private Bounds _cameraBounds;

    [SerializeField] private Transform player;
    private Vector3 _targetPosition;

    private void Awake() => _mainCamera = Camera.main;

    private void Start()
    {
        CalculateCameraBounds();
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference not set in CameraMovement script.");
            return;
        }

        _targetPosition = player.position;
        _targetPosition = GetCameraBounds();

        transform.position = _targetPosition;
    }

    private void CalculateCameraBounds()
    {
        if (Globals.WorldBounds == default)
        {
            Debug.LogError("CameraMovement: Globals.WorldBounds is not set. Ensure SetWorldBoundary runs first.");
            return;
        }

        var height = _mainCamera.orthographicSize;
        var width = height * _mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.max.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.max.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
        );
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(_targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(_targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            transform.position.z
        );
    }
}
