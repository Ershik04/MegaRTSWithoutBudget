using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestData", fileName = "NewQuest", order = 0)]
public class QuestData : ScriptableObject
{
    [SerializeField]
    private string _questName;
    [SerializeField]
    private string _questDescription;
    [SerializeField]
    private ResearchesData _dependencies;

    public string QuestName => _questName;
    public string QuestDescription => _questDescription;
    public ResearchesData Dependencies => _dependencies;
}
