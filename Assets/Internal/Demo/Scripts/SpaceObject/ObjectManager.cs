using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<int, IObject> _objectDic;
    // Start is called before the first frame update
    void Start()
    {
        _objectDic = new Dictionary<int, IObject>();
    }

    public void AddObject(int index, IObject obj)
    {
        _objectDic[index] = obj;
    }

    public void RemoveObject(int index)
    {
        if (_objectDic[index] == null)
            return;

        var obj = _objectDic.Values.ToList().Find(x => x.GetIndex() == index);
        Destroy(obj.GetObject());
    }
}
