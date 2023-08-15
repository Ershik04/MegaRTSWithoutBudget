using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionGeneration : MonoBehaviour
{
    [SerializeField]
    private int _productionCount;
    [SerializeField]
    private City _city;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _maxTimer;

    private void Start()
    {
        _city = GetComponentInParent<City>();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        if (_city != null && _timer <= 0)
        {
            GenerateProduction();
            _timer = _maxTimer;
        }
    }

    private void GenerateProduction()
    {
        _city.AddProduction(_productionCount);
        print("Продукт произведён в городе " + _city.CityName);
    }
}
