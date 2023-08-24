using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour
{
    [SerializeField]
    private ResearchesData _data;
    [SerializeField]
    private CompleteResearches _completeResearches;
    [SerializeField]
    private Button _researchButton;

    private void Start()
    {
        _completeResearches = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CompleteResearches>();
    }

    public void Research()
    {
        if (_completeResearches.Researches.Count > 0 && _data != null)
        {
            for (int i = 0; i < _completeResearches.Researches.Count; i++)
            {
                if (_completeResearches.Researches[i].ResearchName != _data.ResearchName)
                {
                    _completeResearches.AddResearch(_data);
                    _researchButton.interactable = false;
                }
                else
                {
                    print("Исследование уже изучено");
                }
            }
        }
        else if (_completeResearches.Researches.Count <= 0 && _data != null)
        {
            _completeResearches.AddResearch(_data);
            _researchButton.interactable = false;
        }
    }

    public void SetResearch(ResearchesData researchesData, Button researchButton)
    {
        _data = researchesData;
        _researchButton = researchButton;
    }
}
