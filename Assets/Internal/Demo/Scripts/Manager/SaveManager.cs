using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    
    public void Save(TransferInteriorData data)
    {
        string _fileName = "test.json";

        JObject json = data.ToJson();

        var path = Application.streamingAssetsPath + "/" + _fileName;
        if (!System.IO.Directory.Exists(Application.streamingAssetsPath))
        {
            System.IO.Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        var file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
            file.Delete();
            file = new System.IO.FileInfo(path);
        }

        var writer = file.CreateText();
        writer.Write(json);
        writer.Close();
    }
}
