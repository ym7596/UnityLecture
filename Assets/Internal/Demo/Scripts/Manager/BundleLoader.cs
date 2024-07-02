using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleLoader : MonoBehaviour
{

    public void GetAssetBundle(string path, Action<bool, GameObject> onComplete)
    {
        var obj = Resources.Load<GameObject>(path);

        if (obj)
        {
            onComplete?.Invoke(true, obj);
        }
    }

    

     
}
