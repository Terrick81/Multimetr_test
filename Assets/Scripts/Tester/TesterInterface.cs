using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TesterInterface : MonoBehaviour
{
    private const int MAX_CHARACTER_LENGHT = 4;

    [SerializeField]
    private TextMeshPro _display;


    public void SetDisplayText(float v)
    {
        v = (float)Math.Round(v, 2);
        _display.text = v.ToString();
    }

}
