﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataToSave 
{
    public float x, y, z;
    public DataToSave(PauseMenu SaveCheckpoint)
    {
        x = SaveCheckpoint.x;
        y = SaveCheckpoint.y;
        z = SaveCheckpoint.z;
    }
}
