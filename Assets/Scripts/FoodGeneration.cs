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
            GenerateFood();
            _timer = _maxTimer;
        }
    }

    private void GenerateFood()
    {
        _city.AddFood(_foodCount);
        print("Еда произведена");
    }
}
