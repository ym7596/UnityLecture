using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public delegate void SelectedDelegate(int dataIndex);
public delegate IEnumerator LoadThumbnailDelegate(Image img, int dataIndex);

public class ItemCellView : MonoBehaviour
{
    public List<ItemCellRow> rowCells;
}
