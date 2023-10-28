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
    [SerializeField]
    private CityManager _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CityManager>();
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

    private void AttackCity(City city)
    {
        if (city.CityHealth > 0)
        {
            if (city.CityHealth - _damage <= 0)
            {
                CityManager cityManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CityManager>();
                GameObject cityPanel = GameObject.FindGameObjectWithTag("CityPanel");
                if (city != null && cityManager.FindCityInOwn(city))
                {
                    Destroy(city.gameObject);
                    cityPanel.SetActive(false);
                    cityManager.DeleteCityFromOwn(city);
                }
            }
        }
        else
        {
            city.DamageCity(_damage);
        }
    }

    IEnumerator FindCity()
    {
        GameObject[] cities = GameObject.FindGameObjectsWithTag("City");

        for (int i = 0; i < cities.Length; i++)
        {
            City city = cities[i].GetComponent<City>();
            if (!_player.FindCityInOwn(city))
            {
                float distanceToCity = Vector3.Distance(transform.position, city.transform.position);
                if (distanceToCity <= _maxDistanceToCity)
                {
                    AttackCity(city);
                    print("Город " + city.CityName + " атакован");
                }
            }
        }
        yield return new WaitForSeconds(_attackSpeed);
    }
}
