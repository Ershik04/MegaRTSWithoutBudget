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
    private QuestData _dependencies;
    [SerializeField]
    private bool _isConditionCompleted;
    [SerializeField]
    private int _reward;

    public string QuestName => _questName;
    public string QuestDescription => _questDescription;
    public QuestData Dependencies => _dependencies;
    public bool IsQuestConditionComplited => _isConditionCompleted;
    public int RewardCount => _reward;

    public void CompleteQuestCondition()
    {
        _isConditionCompleted = true;
    }

    private void OnValidate()
    {
        _isConditionCompleted = false;
    }
}
