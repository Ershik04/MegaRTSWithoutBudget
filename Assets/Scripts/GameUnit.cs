using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    [SerializeField]
    private bool _selected;
    [SerializeField]
    private int _number;

    public bool Selected => _selected;
    public int Number => _number;


    public void SelectUnit()
    {
        _selected = true;
    }
}
