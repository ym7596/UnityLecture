using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCellRow : MonoBehaviour
{
    private SelectedDelegate _selected;
    private int _dataIndex;

    public Image imgThumbnail;

    public void SetData(int dataIndex, SelectedDelegate selected, LoadThumbnailDelegate loadThumbnail)
    {
        if(dataIndex == -1)
        {
            return;
        }

        _dataIndex = dataIndex;
        StartCoroutine(loadThumbnail(imgThumbnail,_dataIndex));
        _selected = selected;
    }

    public void OnButton_Row()
    {
        if (_dataIndex == -1)
            return;

        _selected?.Invoke(_dataIndex);
    }
}
