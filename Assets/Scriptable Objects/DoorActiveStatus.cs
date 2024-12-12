using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DoorActiveStatus : ScriptableObject
{
    [SerializeField] private bool activeStatusOnReset;
    public bool isDoorCurrentlyActive;

    private void OnEnable()
    {
        isDoorCurrentlyActive = activeStatusOnReset;
    }
}
