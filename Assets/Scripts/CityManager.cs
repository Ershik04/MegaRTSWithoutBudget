using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    [SerializeField]
    private List<City> _cities;

    public List<City> Cities => _cities;

    public void AddCityInOwn(City city)
    {
        _cities.Add(city);
    }

    public void DeleteCityFromOwn(City city)
    {
        _cities.Remove(city);
    }

    public bool FindCityInOwn(City city)
    {
        bool isPlayerCity = false;
        for (int i = 0; i < _cities.Count; i++)
        {
            if (_cities[i] == city)
            {
                isPlayerCity = true;
                return isPlayerCity;
            }
        }
        return isPlayerCity;
    }
}
