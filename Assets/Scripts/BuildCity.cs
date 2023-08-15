using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    [SerializeField]
    private GameObject _builder;
    [SerializeField]
    private GameObject _city;
    [SerializeField]
    private CityGenerator _cityGenerator;
    [SerializeField]
    private CityNameGenerator _cityNameGenerator;

    private void Start()
    {
        _cityGenerator = GameObject.FindGameObjectWithTag("CityGenerator").GetComponent<CityGenerator>();
        _cityNameGenerator = GameObject.FindGameObjectWithTag("CityNameGenerator").GetComponent<CityNameGenerator>();
    }

    public void CreateCity()
    {
        GameObject city = Instantiate(_city, transform.position, transform.rotation);
        _cityGenerator.AddCity(city);
        _cityNameGenerator.AddCity(city);
        _cityNameGenerator.GenerateCityName(city);
        Destroy(gameObject);
    }
}
