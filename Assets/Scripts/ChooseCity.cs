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
    private bool _isUnitCreating;
    [SerializeField]
    private bool _isBuilderCreating;
    [SerializeField]
    private GameUnit _builder;
    [SerializeField]
    private float _builderTimer;
    [SerializeField]
    private bool _isSoldierCreating;
    [SerializeField]
    private GameUnit _soldier;
    [SerializeField]
    private float _soldierTimer;
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
    private GameObject _player;
    [SerializeField]
    private CityManager _cityManager;
    [SerializeField]
    private CompleteResearches _completeResearches;
    [SerializeField]
    private ResearchesData _factoriesResearch;

    private void Start()
    {
        _cityPanel = GameObject.FindGameObjectWithTag("CityPanel");
        _unitPanel = GameObject.FindGameObjectWithTag("UnitPanel");
        _player = GameObject.FindGameObjectWithTag("MainCamera");
        _cityManager = _player.GetComponent<CityManager>();
        _completeResearches = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CompleteResearches>();
        _destroyCityButton = GameObject.FindGameObjectWithTag("DestroyCityButton").GetComponent<Button>();
        _destroyCityButton.onClick.AddListener(DestroyCity);
    }

    public void Update()
    {
        if (_builderTimer > 0)
        {
            _builderTimer -= Time.deltaTime;
        }
        if (_soldierTimer > 0)
        {
            _soldierTimer -= Time.deltaTime;
        }
        SpawnUnit();
    }

    public void SaveCity(City city)
    {
        _city = city;
    }

    private void DestroyCity()
    {
        CityManager cityManager = GetComponent<CityManager>();
        if (_city != null && cityManager.FindCityInOwn(_city))
        {
            City city;
            city = _city;
            Destroy(_city.gameObject);
            _city = null;
            _cityPanel.SetActive(false);
            cityManager.DeleteCityFromOwn(city);
        }
    }

    public void CreateBuilder()
    {
        UnitsData builderData = _builder.GetComponent<UnitView>().UnitData;
        if (_isUnitCreating == false && builderData.NeedFood <= _city.CityFoodCount && builderData.NeedProduction <= _city.CityProductionCount)
        {
            _builderTimer = builderData.UnitCreationTimer;
            _city.SpendFood(builderData.NeedFood);
            _city.SpendProduction(builderData.NeedProduction);
            _isBuilderCreating = true;
            _isUnitCreating = true;
        }
    }

    public void CreateSoldier()
    {
        UnitsData soldierData = _soldier.GetComponent<UnitView>().UnitData;
        if (_isUnitCreating == false && soldierData.NeedFood <= _city.CityFoodCount && soldierData.NeedProduction <= _city.CityProductionCount)
        {
            _soldierTimer = soldierData.UnitCreationTimer;
            _city.SpendFood(soldierData.NeedFood);
            _city.SpendProduction(soldierData.NeedProduction);
            _isSoldierCreating = true;
            _isUnitCreating = true;
        }
    }

    private void SpawnUnit()
    {
        UnitsManager unitsManager = _player.GetComponent<UnitsManager>();
        if (_builderTimer <= 0 && _isUnitCreating && _isBuilderCreating)
        {
            Vector3 offset = new Vector3(2.5f, 0, 0);
            GameUnit gameUnit = Instantiate(_builder, _city.transform.position + offset, _city.transform.rotation);
            unitsManager.AddUnitInOwn(gameUnit);
            _isBuilderCreating = false;
            _isUnitCreating = false;
        }
        else if (_soldierTimer <= 0 && _isUnitCreating && _isSoldierCreating)
        {
            Vector3 offset = new Vector3(2.5f, 0, 0);
            GameUnit gameUnit = Instantiate(_soldier, _city.transform.position + offset, _city.transform.rotation);
            unitsManager.AddUnitInOwn(gameUnit);
            gameUnit.GetComponent<Soldier>().SetCityList(_cityManager.Cities);
            _isSoldierCreating = false;
            _isUnitCreating = false;
        }
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
