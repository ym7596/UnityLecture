using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    [SerializeField] private CategorySO _categorySO;

    [SerializeField] private SpaceObjectDataSO _spaceObjectDataSO;

    [SerializeField] private Transform _categoryRoot;
    [SerializeField] private Transform _itemcellViewRoot;

    [SerializeField] private GameObject _categoryPrefab;
    [SerializeField] private GameObject _cellPrefab;
    private List<ToggleCategory> _categoryToggles;
    void Start()
    {
        _categoryToggles = new List<ToggleCategory>();
        
        SetCategory(_categorySO.categoryModels);
    }


    private void SetCategory(List<CategoryModel> categories)
    {
        foreach (var i in categories)
        {
            var category = Instantiate(_categoryPrefab).GetComponent<ToggleCategory>();
            _categoryToggles.Add(category);
        }
    }
}
