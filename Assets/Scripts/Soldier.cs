using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField]
    private List<City> _playerCities;
    [SerializeField]
    private float _maxDistanceToCity;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _attackSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        StartCoroutine(FindCity());
    }

    public void AddCityToSoldierData(City city)
    {
        _playerCities.Add(city);
    }

    public void SetCityList(List<City> cities)
    {
        _playerCities = cities;
    }

    IEnumerator FindCity()
    {
        GameObject[] cities = GameObject.FindGameObjectsWithTag("City");

        for (int i = 0; i < cities.Length; i++)
        {
            City city = cities[i].GetComponent<City>();
            for (int a = 0; a < _playerCities.Count; a++)
            {
                float distanceToCity = Vector3.Distance(transform.position, city.transform.position);
                if (city != _playerCities[a] && distanceToCity <= _maxDistanceToCity)
                {
                    print("Город " + city.CityName + " атакован");
                }
            }
        }
        yield return new WaitForSeconds(_attackSpeed);
    }
}
