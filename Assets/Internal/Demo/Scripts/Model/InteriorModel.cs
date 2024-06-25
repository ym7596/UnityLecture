using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class InteriorModel
{
    public string id;
    public string category;
    public BundleData bundleData;

    public JObject ToJson()
    {
        return JObject.FromObject(this);
    }

}
