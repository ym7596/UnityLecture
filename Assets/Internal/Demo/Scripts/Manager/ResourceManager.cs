using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private SpaceObjectDataSO _spaceObjectDataSO;

    public void RequestObject(string id)
    {
        var bundle = _spaceObjectDataSO.interiorModels.Find(x => x.id == id);
        if(bundle != null)
        {
            var obj = Resources.Load(bundle.bundleData.path);
            Instantiate(obj);
        }
    }
    
    
}
