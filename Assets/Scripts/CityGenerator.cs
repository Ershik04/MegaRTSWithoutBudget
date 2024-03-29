using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _template;
    [SerializeField]
    private float _tileSize;
    [SerializeField]
    private int _citiesCount;
    [SerializeField]
    private GameObject _tile;
    [SerializeField]
    private CityNameGenerator _cityNameGenerator;
    [SerializeField]
    private List<GameObject> _cities;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private List<GameUnit> _soldiers;
    [SerializeField]
    private UnitsData _soldier;
    [SerializeField]
    private SaveData _playerPrefs;

    public List<GameObject> Cities => _cities;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera");
        _playerPrefs = GameObject.FindGameObjectWithTag("SavesGenerator").GetComponent<SaveData>();
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Grass");
        for (int i = 0; i < _citiesCount; i++)
        {
            _tile = tiles[Random.Range(0, tiles.Length)];
            float xposition = Random.Range(-_tileSize, _tileSize);
            float zposition = Random.Range(-_tileSize, _tileSize);
            Vector3 position = new Vector3(xposition += _tile.transform.position.x, 0, zposition += _tile.transform.position.z);
            GameObject city = Instantiate(_template, position, gameObject.transform.rotation);
            city.tag = "City";
            AddCity(city);
            _cityNameGenerator.AddCity(city);
            _player.GetComponent<CityManager>().AddCityInOwn(city.GetComponent<City>());
        }
        _cityNameGenerator.GenerateCitiesNames();
    }

    public void AddCity(GameObject city)
    {
        _cities.Add(city);
    }

    public void SaveCityData()
    {
        for (int c = 0; c < _cities.Count; c++)
        {
            _playerPrefs.SaveCityPosition(_cities[c].GetComponent<City>());
            _cityNameGenerator.SaveCitiesNames(c);
        }
    }

    public void LoadCitiesData()
    {
        for (int c = 0; c < _cities.Count; c++)
        {
            _cities[c].transform.position = _playerPrefs.LoadCityPosition();
            _cityNameGenerator.LoadCitiesNames(c);
        }
    }
}
