using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpaceObjectDataSO))]
public class BundleDataEditor : Editor
{
    private SpaceObjectDataSO _target;

    private void OnEnable()
    {
        _target = (SpaceObjectDataSO)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (_target == null)
            return;

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("DataLoad") == true)
            Load(_target.textAsset.text);

        if (GUILayout.Button("DataSave") == true)
            Save();

        EditorGUILayout.EndHorizontal();
            
    }

    private void Load(string data)
    {
        if (string.IsNullOrEmpty(data))
            return;

        _target.interiorModels.Clear();

        var jsonArray = JArray.Parse(data);
        Debug.Log(jsonArray.ToString());
        foreach (var json in jsonArray)
        {
            InteriorModel formatInfo = json.ToObject<InteriorModel>();
            _target.interiorModels.Add(formatInfo);
        }
    }

    private void Save()
    {
        if(_target.interiorModels == null || _target.interiorModels.Count == 0) return;

        string assetPath = AssetDatabase.GetAssetPath(_target);

        JArray jsonArray = new JArray();

        foreach(var bundle in _target.interiorModels)
        {
            var json = bundle.ToJson();
            jsonArray.Add(json);
        }

        string assetName = Path.GetFileName(assetPath);
        assetPath = assetPath.Replace(assetName, "");
        File.WriteAllText($"{assetPath}/bundleData.json",jsonArray.ToString());
        AssetDatabase.Refresh();
    }
}
