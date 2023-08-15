using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public string CityName;
    [SerializeField]
    private int _cityFoodCount;
    [SerializeField]
    private int _cityProductionCount;
    [SerializeField]
    private int _cityPowerCount;
    [SerializeField]
    private List<FoodGeneration> _farms;
    [SerializeField]
    private List<ProductionGeneration> _factories;

    public int CityFoodCount => _cityFoodCount;
    public int CityProductionCount => _cityProductionCount;
    public int CityPowerCount => _cityPowerCount;
    public List<FoodGeneration> Farms => _farms;
    public List<ProductionGeneration> Factories => _factories;

    public void AddFarm(FoodGeneration farm)
    {
        _farms.Add(farm);
    }

    public void AddFood(int foodCount)
    {
        _cityFoodCount += foodCount;
    }

    public void AddFactory(ProductionGeneration factory)
    {
        _factories.Add(factory);
    }

    public void AddProduction(int productionCount)
    {
        _cityProductionCount += productionCount;
    }
}
