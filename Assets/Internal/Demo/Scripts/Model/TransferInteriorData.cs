using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TransferInteriorData
{
    public string spaceId;
    public List<InteriorData> interiorDataList;

    public  TransferInteriorData()
    {
        spaceId = "";
        interiorDataList = new List<InteriorData>(); 
    }
    public void Add(SpaceObject obj)
    {
        InteriorData data = new InteriorData(obj.ID, obj.Index);
        data.transformData.UpdateTransformData(obj.transform);
        interiorDataList.Add(data);
    }

    public void Remove(SpaceObject obj)
    {
        interiorDataList.Remove(interiorDataList.Find(x => x.index == obj.Index));

    }

    public void UpdateTransformTarget(SpaceObject obj)
    {
        int index = interiorDataList.FindIndex(x => x.index == obj.Index);
        interiorDataList[index].transformData.UpdateTransformData(obj.transform);
    }

    public JObject ToJson()
    {
        JObject jObject = JObject.FromObject(this);

        return jObject;
    }
}

[Serializable]
public class InteriorData
{
    public string bundleId;
    public int index = 0;
    public TransformDatas transformData;

    public InteriorData(string bundleId, int index)
    {
        this.bundleId = bundleId;
        this.index = index;
        transformData = new TransformDatas();
    }
}

[Serializable]
public class TransformDatas
{
    public Vector3Data position;
    public Vector3Data rotation;
    public Vector3Data scale;

    public void UpdateTransformData(Transform t)
    {
        position = new Vector3Data(t.localPosition);
        rotation = new Vector3Data(t.localRotation.eulerAngles);
        scale = new Vector3Data(t.localScale);
    }
}

[Serializable]
public class Vector3Data
{
    public float x;
    public float y;
    public float z;

    public Vector3Data() { }
    public Vector3Data(Vector3 vector)
    {
        this.x = RoundTwo(vector.x);
        this.y = RoundTwo(vector.y);
        this.z = RoundTwo(vector.z);
    }

    private float RoundTwo(float num)
    {
        return Mathf.Round(num * 100f) / 100f;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }

    public static Vector3Data FromVector3(Vector3 vector)
    {
        return new Vector3Data(vector);
    }
}
