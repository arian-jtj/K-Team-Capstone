using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    [SerializeField] private Vector2 valueOnReset;
    public Vector2 initialValue;

    private void OnEnable()
    {
        initialValue = valueOnReset;
    }
}
