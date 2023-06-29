using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsFunctions : MonoBehaviour
{
    [SerializeField]
    private GameObject _singleplayerMenu;
    [SerializeField]
    private string _singleplayerScene;

    public void OpenSingleplayerMenu()
    {
        _singleplayerMenu.SetActive(true);
    }

    public void CloseSingleplayerMenu()
    {
        _singleplayerMenu.SetActive(false);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(_singleplayerScene);
    }
}
