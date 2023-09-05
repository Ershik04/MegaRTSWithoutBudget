using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    [SerializeField]
    private QuestData _data;
    [SerializeField]
    private CompleteQuests _completeQuests;
    [SerializeField]
    private Button _questButton;

    private void Start()
    {
        _completeQuests = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CompleteQuests>();
    }

    public void CompleteQuest()
    {
        if (_completeQuests.Quests.Count > 0 && _data != null)
        {
            for (int i = 0; i < _completeQuests.Quests.Count; i++)
            {
                if (_completeQuests.Quests[i].QuestName != _data.QuestName && _data.IsQuestConditionComplited)
                {
                    if (_data.Dependencies == null)
                    {
                        _completeQuests.AddQuest(_data);
                        Rewards.AddReward(_data.RewardCount);
                        _questButton.interactable = false;
                    }
                    else if (_data.Dependencies.IsQuestConditionComplited)
                    {
                        _completeQuests.AddQuest(_data);
                        Rewards.AddReward(_data.RewardCount);
                        _questButton.interactable = false;
                    }
                    else
                    {
                        print(_data.Dependencies + " ещЄ не выполнен");
                    }
                }
                else
                {
                    print(" вест уже выполнен");
                }
            }
        }
        else if (_completeQuests.Quests.Count <= 0 && _data != null && _data.IsQuestConditionComplited)
        {
            if (_data.Dependencies == null)
            {
                _completeQuests.AddQuest(_data);
                Rewards.AddReward(_data.RewardCount);
                _questButton.interactable = false;
            }
            else if (_data.Dependencies.IsQuestConditionComplited)
            {
                _completeQuests.AddQuest(_data);
                Rewards.AddReward(_data.RewardCount);
                _questButton.interactable = false;
            }
            else
            {
                print(_data.Dependencies + " ещЄ не выполнен");
            }
        }
    }

    public void SetQuest(QuestData questsData, Button questButton)
    {
        _data = questsData;
        _questButton = questButton;
    }
}
