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
    private City _city;

    private void Start()
    {
        _city = gameObject.GetComponent<City>();
        _label = GameObject.FindGameObjectWithTag("CityNameText").GetComponent<TMP_Text>();
    }

    private void OnMouseDown()
    {
        _label.text = _city.CityName;
    }
}
