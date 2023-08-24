using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitsData", fileName = "NewUnit", order = 0)]
public class UnitsData : ScriptableObject
{
    [SerializeField]
    private string _unitName;
    [SerializeField]
    private int _unitHealth;
    [SerializeField]
    private string _unitDescription;
    [SerializeField]
    private Sprite _unitImage;
    [SerializeField]
    private float _unitCreationTimer;
    [SerializeField]
    private int _needFood;
    [SerializeField]
    private int _needProduction;

    public string UnitName => _unitName;
    public int UnitHealth => _unitHealth;
    public string UnitDescription => _unitDescription;
    public Sprite UnitImage => _unitImage;
    public float UnitCreationTimer => _unitCreationTimer;
    public int NeedFood => _needFood;
    public int NeedProduction => _needProduction;
}
