using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    [SerializeField]
    private GameObject _researchPanel;
    [SerializeField]
    private GameObject _cityPanel;
    [SerializeField]
    private GameObject _createUnitPanel;
    [SerializeField]
    private GameObject _cityImprovePanel;
    [SerializeField]
    private GameObject _menuPanel;
    [SerializeField]
    private bool _researchPanelOpen;
    [SerializeField]
    private bool _menuOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _researchPanelOpen)
        {
            CloseResearchPanel();
            _researchPanelOpen = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _menuOpen == false)
        {
            OpenMenuPanel();
            _menuOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _menuOpen)
        {
            CloseMenuPanel();
            _menuOpen = false;
        }
    }

    public void OpenResearchPanel()
    {
        _researchPanel.SetActive(true);
        _researchPanelOpen = true;
    }

    public void CloseResearchPanel()
    {
        _researchPanel.SetActive(false);
        _researchPanelOpen = false;
    }

    public void CloseCityPanel()
    {
        _cityPanel.SetActive(false);
    }

    public void OpenCreateUnitPanel()
    {
        _createUnitPanel.SetActive(true);
    }

    public void CloseCreateUnitPanel()
    {
        _createUnitPanel.SetActive(false);
    }

    public void OpenImproveCityPanel()
    {
        _cityImprovePanel.SetActive(true);
    }

    public void CloseImproveCityPanel()
    {
        _cityImprovePanel.SetActive(false);
    }

    public void OpenMenuPanel()
    {
        _menuPanel.SetActive(true);
        _menuOpen = true;
    }

    public void CloseMenuPanel()
    {
        _menuPanel.SetActive(false);
        _menuOpen = false;
    }

    public void Quit()
    {

    }
}
