using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteResearches : MonoBehaviour
{
    [SerializeField]
    private List<ResearchesData> _researches;

    public List<ResearchesData> Researches => _researches;

    public void AddResearch(ResearchesData researchesData)
    {
        _researches.Add(researchesData);
    }
}
