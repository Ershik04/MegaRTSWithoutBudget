using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityNameGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _cities;
    [SerializeField]
    private string[] _vowels;
    [SerializeField]
    private string[] _consonants;
    [SerializeField]
    private int _minCityNameLength;
    [SerializeField]
    private int _maxCityNameLength;
    [SerializeField]
    private string _output;

    public void AddCity(GameObject city)
    {
        _cities.Add(city);
    }

    public void GenerateCitiesNames()
    {
        for (int c = 0; c < _cities.Count; c++)
        {
            int i = Random.Range(_minCityNameLength, _maxCityNameLength);
            for (int a = 0; a < i; a++)
            {
                int b = Random.Range(0, 2);
                if (b == 0)
                {
                    _output += _vowels[Random.Range(0, _vowels.Length)];
                }
                else
                {
                    _output += _consonants[Random.Range(0, _consonants.Length)];
                }
            }
            _cities[c].GetComponent<City>().CityName = _output;
            _output = "";
        }
    }
}
