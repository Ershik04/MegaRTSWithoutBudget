using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    [SerializeField]
    private GameObject _researchPanel;
    [SerializeField]
    private GameObject _questPanel;
    [SerializeField]
    private GameObject _cityPanel;
    [SerializeField]
    private GameObject _createUnitPanel;
    [SerializeField]
    private GameObject _cityImprovePanel;
    [SerializeField]
    private GameObject _menuPanel;
    [SerializeField]
    private GameObject _builderPanel;
    [SerializeField]
    private bool _researchPanelOpen;
    [SerializeField]
    private bool _questPanelOpen;
    [SerializeField]
    private bool _menuOpen;
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _researchPanelOpen)
        {
            CloseResearchPanel();
            _researchPanelOpen = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _questPanelOpen)
        {
            CloseQuestPanel();
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

    public void OpenQuestPanel()
    {
        _questPanel.SetActive(true);
        _questPanelOpen = true;
    }

    public void CloseQuestPanel()
    {
        _questPanel.SetActive(false);
        _questPanelOpen = false;
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

    public void OpenBuilderPanel()
    {
        _builderPanel.SetActive(true);
    }

    public void CloseBuilderPanel()
    {
        _builderPanel.SetActive(false);
    }

    public void BuildCity()
    {
        ChooseUnit chooseUnit = _player.GetComponent<ChooseUnit>();
        if (chooseUnit.ChoosedUnit != null)
        {
            Builder builder;
            bool isBuilder;
            isBuilder = chooseUnit.ChoosedUnit.TryGetComponent<Builder>(out builder);
            if (isBuilder)
            {
                builder.BuildCity();
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
