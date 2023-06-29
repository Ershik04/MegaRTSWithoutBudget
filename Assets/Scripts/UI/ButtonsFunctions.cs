using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    [SerializeField]
    private GameObject _researchPanel;

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
}
