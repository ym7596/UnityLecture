using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectRoot : MonoBehaviour
{
    protected string id;
    protected string category;
    protected int index;

    protected virtual void Start()
    {
        
    }

    public virtual void SetData(string id, string category, int index)
    {
        this.id = id;
        this.category = category;
        this.index = index;
    }
}
