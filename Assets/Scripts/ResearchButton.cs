using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchButton : MonoBehaviour
{
    [SerializeField]
    private ResearchesData _data;
    [SerializeField]
    private CompleteResearches _completeResearches;

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
                    print(1);
                    _completeResearches.AddResearch(_data);
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
        }
    }

    public void SetResearch(ResearchesData researchesData)
    {
        _data = researchesData;
    }
}
