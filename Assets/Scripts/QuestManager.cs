using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private QuestData _factoryQuest;
    [SerializeField]
    private QuestData _builder;

    private void Start()
    {
        _player = gameObject;
    }

    private void Update()
    {
        FactoryQuestCondition();
    }

    private void FactoryQuestCondition()
    {
        CityManager cityManager = _player.GetComponent<CityManager>();
        for (int i = 0; i < cityManager.Cities.Count; i++)
        {
            if (cityManager.Cities[i].Factories.Count >= 3)
            {
                _factoryQuest.CompleteQuestCondition();
                return;
            }
        }
    }

    private void BuilderQuestCondition()
    {

    }
}
