using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public string CityName;
    [SerializeField]
    private int _cityFoodCount;
    [SerializeField]
    private int _cityPowerCount;

    public int CityFoodCount => _cityFoodCount;
    public int CityPowerCount => _cityPowerCount;
}
