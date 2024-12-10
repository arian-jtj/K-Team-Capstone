using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int clearedLevel;
    public int currentLevel;
    public Vector2 Vector2;

    public GameData()
    {
        clearedLevel = 0;
        currentLevel = 1;
        this.Vector2 = new Vector2();
    }
}
