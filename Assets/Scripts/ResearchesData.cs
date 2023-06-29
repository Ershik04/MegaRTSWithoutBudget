using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ResearchData", fileName = "NewResearch", order = 0)]
public class ResearchesData : ScriptableObject
{
    [SerializeField]
    private string _researchName;
    [SerializeField]
    private string _researchDescription;
    [SerializeField]
    private ResearchesData _dependencies;

    public string ResearchName => _researchName;
    public string ResearchDescription => _researchDescription;
    public ResearchesData Dependencies => _dependencies;
}
