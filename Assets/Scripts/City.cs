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
    [SerializeField]
    private List<FoodGeneration> _farms;

    public int CityFoodCount => _cityFoodCount;
    public int CityPowerCount => _cityPowerCount;
    public List<FoodGeneration> Farms => _farms;

    public void AddFarm(FoodGeneration farm)
    {
        _farms.Add(farm);
    }

    public void AddFood(int foodCount)
    {
        _cityFoodCount += foodCount;
    }
}
