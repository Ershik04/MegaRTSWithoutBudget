using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _foodCount;
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private City _city;
    [SerializeField]
    private CityGenerator _cityGenerator;

    private void Start()
    {
        _cityGenerator = GameObject.FindGameObjectWithTag("Generator").GetComponent<CityGenerator>();
        FindCity();
        if (_city != null)
        {
            StartCoroutine(GenerateFood());
        }
    }

    private void FindCity()
    {
        for (int i = 0; 0 < _cityGenerator.Cities.Count; i++)
        {
            _city = _cityGenerator.Cities[i].GetComponent<City>();
            float position = Vector3.Distance(transform.position, _city.transform.position);
            if (position <= _maxDistance)
            {
                print(1);
                _city = _cityGenerator.Cities[i].GetComponent<City>();
                return;
            }
            else
            {
                print(2);
                FindCity();
            }
        }
    }

    private IEnumerator GenerateFood()
    {
        print(3);
        yield return new WaitForSeconds(1);
    }
}
