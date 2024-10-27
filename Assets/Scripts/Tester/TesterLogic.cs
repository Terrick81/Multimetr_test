using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TesterLogic : MonoBehaviour
{
    [SerializeField]
    private float _pover;
    [SerializeField]
    private float _resistance;
    
    public void SetParametr(float p, float r)
    {
        if (p < 0) p = 0;
        if (r < 0) r = 0;

        _pover = p;
        _resistance = r;

    }
    
    public float GetValue(States state)
    {
        switch (state)
        {
            case States.off:
                return 0;
            case States.constantVoltage:
                return GetConstantVoltage(); ;
            case States.alternatingVoltage:
                return GetAlternatingVoltage();
            case States.currentStrength:
                return GetCurrentStrength();
            case States.resistance:
                return GetResistance();
        }
        return 0;
    }

    public float[] GetAllValue()
    {
        float[] values = new float[4];

        values[0] = GetConstantVoltage();
        values[1] = GetCurrentStrength();
        values[2] = GetAlternatingVoltage();
        values[3] = GetResistance();
        return values;
    }

    private float GetConstantVoltage()
    {
        return (float)Math.Sqrt(_pover * _resistance);
    }
    private float GetCurrentStrength()
    {
        return (float)Math.Sqrt(_pover / _resistance);
    }
    private float GetAlternatingVoltage()
    {
        return 0.01f;
    }
    private float GetResistance()
    {
        return _resistance;
    }
}
