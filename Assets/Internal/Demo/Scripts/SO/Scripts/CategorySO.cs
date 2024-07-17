using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="categorySO",menuName ="SpaceObjects/categorySO")]
public class CategorySO : ScriptableObject
{
    public List<CategoryModel> categoryModels;

    public CategorySO()
    {
        categoryModels = new List<CategoryModel>();
    }
}
