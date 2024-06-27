using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    private TestClass _testClass;
    private string tttl = "";
    private void Start()
    {
        tttl = "abcd";
        TestSET();
    }

    private void TestSET()
    {
        ObjectInfo objinfo = new ObjectInfo()
        {
            scoreId = "score1",
            userId = "user1"
        };
        ObjectInfo objinfo2 = new ObjectInfo()
        {
            scoreId = "score2",
            userId = "user2"
        };
        ScoreInfo scoreInfo = new ScoreInfo()
        {
            id = "score1",
            score = 100
        };
        ScoreInfo scoreInfo2 = new ScoreInfo()
        {
            id = "score2",
            score = 200
        };

        UserInfo userInfo = new UserInfo()
        {
            id = "user1",
            age = 17,
            name = "dduR"
        };
        UserInfo userInfo2 = new UserInfo()
        {
            id = "user2",
            age = 27,
            name = "dduR2"
        };
        _testClass = new TestClass();
        _testClass.objectInfos.Add(objinfo);
        _testClass.objectInfos.Add(objinfo2);
        _testClass.scoreInfos.Add(scoreInfo);
        _testClass.scoreInfos.Add(scoreInfo2);
        _testClass.userInfos.Add(userInfo);
        _testClass.userInfos.Add(userInfo2);
    }
    
    public void SetJsonUtility()
    {
        var testjson = JsonUtility.ToJson(_testClass);
        Debug.Log(testjson);
    }

    public void SetNewton()
    {
        string json = JsonConvert.SerializeObject(_testClass);
        JObject test = new JObject();
        test.Add("id",tttl);
        test.Add("data",_testClass.ToJson());
        Debug.Log(json);
    }
}
