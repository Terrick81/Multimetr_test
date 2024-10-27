using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _fields;

    private static UIManager uIManager;


    private void Awake()
    {
        uIManager = GetComponent<UIManager>();
    }
    public static void SetAllTesterState(float[] doubles)
    {
        string t = "";
        foreach (var value in doubles) 
        {
            t += Math.Round(value, 2).ToString() + "\n";
        }

        uIManager._fields.text = t;
    }


}
