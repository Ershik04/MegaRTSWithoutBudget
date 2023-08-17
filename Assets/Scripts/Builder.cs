using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField]
    private GameObject _builder;
    [SerializeField]
    private GameObject _city;
    [SerializeField]
    private CityGenerator _cityGenerator;
    [SerializeField]
    private CityNameGenerator _cityNameGenerator;
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera");
        _cityGenerator = GameObject.FindGameObjectWithTag("Generator").GetComponent<CityGenerator>();
        _cityNameGenerator = GameObject.FindGameObjectWithTag("CityNameGenerator").GetComponent<CityNameGenerator>();
    }

    public void BuildCity()
    {
        GameObject city = Instantiate(_city, transform.position, transform.rotation);
        _cityGenerator.AddCity(city);
        _cityNameGenerator.AddCity(city);
        _cityNameGenerator.GenerateCityName(city);
        ChooseUnit chooseUnit = _player.GetComponent<ChooseUnit>();
        chooseUnit.DisbandUnit();
    }
}