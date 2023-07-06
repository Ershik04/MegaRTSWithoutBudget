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

    private void Start()
    {
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
        }
    }

    public void CreateBuilder()
    {
        Vector3 offset = new Vector3(2.5f, 0, 0);
        Instantiate(_builder, _city.transform.position + offset, _city.transform.rotation);
    }
}
