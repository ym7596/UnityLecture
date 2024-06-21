using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : ObjectRoot, IObject
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    public int GetIndex()
    {
        return index;
    }

    public GameObject GetObject()
    {
        return this.gameObject;
    }

    public void SetSelect()
    {
        
    }

 
}
