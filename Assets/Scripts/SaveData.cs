using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void SaveCityName(City city)
    {
        PlayerPrefs.SetString("CityName", city.CityName);
        print(PlayerPrefs.GetString("CityName"));
    }

    public void SaveCityPosition(City city)
    {
        PlayerPrefs.SetFloat("CityPositionX", city.transform.position.x);
        PlayerPrefs.SetFloat("CityPositionY", city.transform.position.y);
        PlayerPrefs.SetFloat("CityPositionZ", city.transform.position.z);
        print(PlayerPrefs.GetFloat("CityPositionX"));
        print(PlayerPrefs.GetFloat("CityPositionY"));
        print(PlayerPrefs.GetFloat("CityPositionZ"));
    }

    public string LoadCityName()
    {
        string cityName = PlayerPrefs.GetString("CityName");
        return cityName;
    }

    public Vector3 LoadCityPosition()
    {
        Vector3 position = new Vector3(PlayerPrefs.GetFloat("CityPositionX"), PlayerPrefs.GetFloat("CityPositionY"), PlayerPrefs.GetFloat("CityPositionZ"));
        return position;
    }
}
