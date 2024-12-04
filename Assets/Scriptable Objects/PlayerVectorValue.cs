using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerVectorValue : ScriptableObject
{
    [SerializeField] private Vector2 valueOnReset; //value when the play button is pressed
    public Vector2 changingValue;

    private void OnEnable()
    {
        changingValue = valueOnReset;
    }
}