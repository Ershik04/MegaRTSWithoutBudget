using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisbandButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private GameObject _unit;

    private void Start()
    {
        _button.onClick.AddListener(DisbandUnit);
    }
    
    private void DisbandUnit()
    {
        Destroy(_unit);
    }
}
