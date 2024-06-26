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
    public string bundleKey;
    public List<string> assetKey;
    public string path = "";
    
    [JsonConstructor]
    public BundleData(string bundleId, string thumbnailId, string path,string bundleKey,List<string> assetKey) { 
        this.bundleId = bundleId;
        this.thumbnailId = thumbnailId;
        this.path = path;
        this.bundleKey = bundleKey;
        this.assetKey = assetKey;
    }

    public string ToJson()
    {
        return JObject.FromObject(this).ToString();
    }

}
