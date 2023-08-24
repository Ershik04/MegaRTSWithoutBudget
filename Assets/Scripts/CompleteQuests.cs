using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuests : MonoBehaviour
{
    [SerializeField]
    private List<QuestData> _quests;

    public List<QuestData> Quests => _quests;

    public void AddQuest(QuestData questData)
    {
        _quests.Add(questData);
    }
}
