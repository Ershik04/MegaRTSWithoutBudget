using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _cityFoodCount;
    [SerializeField]
    private City _city;
    [SerializeField]
    private GameObject _cityMenu;
    [SerializeField]
    private ChooseCity _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ChooseCity>();
        _city = gameObject.GetComponent<City>();
        _cityMenu = GameObject.FindGameObjectWithTag("CityPanel");
        _label = GameObject.FindGameObjectWithTag("CityNameText").GetComponent<TMP_Text>();
        _cityFoodCount = GameObject.FindGameObjectWithTag("CityFoodCount").GetComponent<TMP_Text>();
    }

    private void OnMouseDown()
    {
        _cityMenu.SetActive(true);
        _label.text = _city.CityName;
        _cityFoodCount.text = _city.CityFoodCount.ToString();
        _player.SaveCity(_city);
    }
}
