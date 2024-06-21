using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectData
{
    public string id;
    public int index;

    public ObjectData(string id, int index)
    {
        this.id = id;
        this.index = index;
    }
}
