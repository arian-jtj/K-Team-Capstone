using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveFileScene : ScriptableObject
{
    [SerializeField] private string sceneOnReset;
    public string sceneForSaveFile;

    private void OnEnable()
    {
        sceneForSaveFile = sceneOnReset;
    }
}
