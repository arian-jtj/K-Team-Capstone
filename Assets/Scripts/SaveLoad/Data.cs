using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int clearedLevel;
    public string currentLevel;
    public Vector2 playerCurrentPosition;

    public GameData()
    {
        clearedLevel = 0;
        currentLevel = "";
        this.playerCurrentPosition = Vector2.zero;
    }
}
