using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;


public class TestClass
{
    public string id;
    
    public List<ObjectInfo> objectInfos;
    public List<UserInfo> userInfos;
    public List<ScoreInfo> scoreInfos;

    public TestClass()
    {
        objectInfos = new List<ObjectInfo>();
        userInfos = new List<UserInfo>();
        scoreInfos = new List<ScoreInfo>();
    }

    public JObject ToJson()
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
        string json = JsonConvert.SerializeObject(this, settings);
        return JObject.Parse(json);
    }
}

[Serializable]
public class UserInfo
{
    public string id;
    public string name;
    public int age;
}
[Serializable]
public class ScoreInfo
{
    public string id;
    public int score;
}
[Serializable]
public class ObjectInfo
{
    public string scoreId;
    public string userId;
}

