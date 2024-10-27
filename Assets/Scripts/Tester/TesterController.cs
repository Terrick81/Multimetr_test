using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum States
{
    off,
    constantVoltage,
    alternatingVoltage,
    currentStrength,
    resistance,
}

public class TesterControler : MonoBehaviour
{
    public const int COUNT_OF_SELECTOR_POS = 5;
    private bool _selectorIsActive = false;
    private int _currentPosition = 0;
    private TesterLogic _testerLogic;
    private TesterInterface _testerInterface;

    [SerializeField]
    private States _currentState;

    



    private void OnEnable()
    {
        SelectorLogic.AddListener(SetSelectorIsActive);
    }

    private void Awake()
    {
        _testerLogic = GetComponent<TesterLogic>();
        _testerInterface = GetComponent<TesterInterface>();
    }


    private void Start()
    {
        _testerLogic.SetParametr(p: 400, r: 1000);
    }
    private void UpdateCurrentState()
    {
        if (_currentPosition < 0)
        {
            _currentState = 
                (States) COUNT_OF_SELECTOR_POS - Mathf.Abs(_currentPosition % COUNT_OF_SELECTOR_POS);
        }
        else
        {
            _currentState =
                 (States) Mathf.Abs(_currentPosition % COUNT_OF_SELECTOR_POS);
        }
    }
    private void SetSelectorIsActive(bool state)
    {
        _selectorIsActive = state;
    }
    void Update()
    {
        if (_selectorIsActive)
        {
            float _scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (_scrollWheel != 0)
            {
                _currentPosition += (int)(_scrollWheel * 10);
                UpdateCurrentState();
                SelectorLogic.SetRotationStatic((int)_currentState);
                float v = _testerLogic.GetValue(_currentState);
                
                _testerInterface.SetDisplayText(v);
                UIManager.SetAllTesterState(_testerLogic.GetAllValue());
                
            }
        }
    }
    private void OnDisable()
    {
        SelectorLogic.RemoveListener(SetSelectorIsActive);
    }
}
