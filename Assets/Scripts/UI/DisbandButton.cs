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
    [SerializeField]
    private GameObject _unitPanel;

    private void Start()
    {
        
    }
    
    private void DisbandUnit()
    {
        Destroy(_unit);
    }
}
