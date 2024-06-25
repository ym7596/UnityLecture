using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BundleData
{
    public string bundleId="";
    public string thumbnailId="";
    public string path = "";

    public BundleData(JObject json)
    {
        Debug.Log(json.ToString());
        bundleId = json[nameof(bundleId)].ToString();
        thumbnailId = json[nameof(thumbnailId)].ToString();
        path = json[nameof(path)].ToString();
    }

    [JsonConstructor]
    public BundleData(string bundleId, string thumbnailId, string path) { 
        this.bundleId = bundleId;
        this.thumbnailId = thumbnailId;
        this.path = path;
    }

    public string ToJson()
    {
        return JObject.FromObject(this).ToString();
    }

}
