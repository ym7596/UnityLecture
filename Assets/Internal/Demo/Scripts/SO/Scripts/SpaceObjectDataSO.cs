using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="spaceDataSO",menuName ="SpaceObjects/spaceDataSO")]
public class SpaceObjectDataSO : ScriptableObject
{
    public TextAsset textAsset;
    public List<InteriorModel> interiorModels;
}
