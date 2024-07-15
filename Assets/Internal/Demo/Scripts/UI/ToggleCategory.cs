using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCategory : MonoBehaviour
{
    public Image img;
    public event Action onToggle_Clicked;

    public void SetData(Sprite sprite)
    {
        img.sprite = sprite;
    }

    public void OnToggle_ValueChanged(bool isOn)
    {
        if(isOn)
            onToggle_Clicked?.Invoke();
    }

}
