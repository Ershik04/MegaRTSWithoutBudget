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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseResearchPanel();
        }
    }

    public void OpenResearchPanel()
    {
        _researchPanel.SetActive(true);
    }

    public void CloseResearchPanel()
    {
        _researchPanel.SetActive(false);
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
}
