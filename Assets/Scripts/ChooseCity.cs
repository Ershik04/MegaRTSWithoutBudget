using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCity : MonoBehaviour
{
    [SerializeField]
    private City _city;
    [SerializeField]
    private Button _destroyCityButton;
    [SerializeField]
    private GameUnit _builder;
    [SerializeField]
    private FoodGeneration _farm;
    [SerializeField]
    private ProductionGeneration _factory;
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _minDistance;
    [SerializeField]
    private int _maxFarmsCount;
    [SerializeField]
    private int _maxFactoriesCount;
    [SerializeField]
    private GameObject _cityPanel;
    [SerializeField]
    private GameObject _unitPanel;
    [SerializeField]
    private CompleteResearches _completeResearches;
    [SerializeField]
    private ResearchesData _factoriesResearch;

    private void Start()
    {
        _cityPanel = GameObject.FindGameObjectWithTag("CityPanel");
        _unitPanel = GameObject.FindGameObjectWithTag("UnitPanel");
        _completeResearches = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CompleteResearches>();
        _destroyCityButton = GameObject.FindGameObjectWithTag("DestroyCityButton").GetComponent<Button>();
        _destroyCityButton.onClick.AddListener(DestroyCity);
    }

    public void SaveCity(City city)
    {
        _city = city;
    }

    private void DestroyCity()
    {
        if (_city != null)
        {
            Destroy(_city.gameObject);
            _city = null;
            _cityPanel.SetActive(false);
        }
    }

    public void CreateBuilder()
    {
        Vector3 offset = new Vector3(2.5f, 0, 0);
        GameUnit gameUnit = Instantiate(_builder, _city.transform.position + offset, _city.transform.rotation);
    }

    public void CreateFarm()
    {
        if (_city.Farms.Count < _maxFarmsCount)
        {
            float positionx = Random.Range(Random.Range(_minDistance, _maxDistance), Random.Range(-_minDistance, -_maxDistance));
            float positionz = Random.Range(Random.Range(_minDistance, _maxDistance), Random.Range(-_minDistance, -_maxDistance));
            Vector3 offset = new Vector3(positionx, 0, positionz);
            FoodGeneration farm = Instantiate(_farm, _city.transform.position + offset, _city.transform.rotation, _city.transform);
            _city.AddFarm(farm);
        } 
        else
        {
            print("Слишком много ферм в городе " + _city.CityName);
        }
    }

    public void CreateFactory()
    {
        for (int i = 0; i < _completeResearches.Researches.Count; i++)
        {
            if (_completeResearches.Researches[i] == _factoriesResearch)
            {
                if (_city.Factories.Count < _maxFactoriesCount)
                {
                    float positionx = Random.Range(Random.Range(_minDistance, _maxDistance), Random.Range(-_minDistance, -_maxDistance));
                    float positionz = Random.Range(Random.Range(_minDistance, _maxDistance), Random.Range(-_minDistance, -_maxDistance));
                    Vector3 offset = new Vector3(positionx, 0, positionz);
                    ProductionGeneration factory = Instantiate(_factory, _city.transform.position + offset, _city.transform.rotation, _city.transform);
                    _city.AddFactory(factory);
                }
                else
                {
                    print("Слишком много фабрик в городе " + _city.CityName);
                }
                return;
            }
        }
    }
}
