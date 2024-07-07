using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    private string id;
    private string category;
    private int index;

    private Material _material;
    // Start is called before the first frame update
    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void SetData(string id, string category, int index)
    {
        this.id = id;
        this.category = category;
        this.index = index;
    }
   
    public void SetSelect(bool isSelect)
    {
        if (isSelect)
            _material.color = Color.green;
        else _material.color = Color.white;
    }

 
}
