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
    private QuestData _builderQuest;
    [SerializeField]
    private QuestData _citiesQuest;
    [SerializeField]
    private QuestData _soldierQuest;

    private void Start()
    {
        _player = gameObject;
    }

    private void Update()
    {
        FactoryQuestCondition();
        BuilderQuestCondition();
        CitiesQuestComplite();
        SoldierQuestCondition();
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
        UnitsManager unitsManager = _player.GetComponent<UnitsManager>();
        Builder builder;
        for (int i = 0; i < unitsManager.GameUnits.Count; i++)
        {
            if (unitsManager.GameUnits[i].TryGetComponent<Builder>(out builder))
            {
                _builderQuest.CompleteQuestCondition();
                return;
            }
        }
    }

    private void CitiesQuestComplite()
    {
        CityManager cityManager = _player.GetComponent<CityManager>();
        if (cityManager.Cities.Count >= 5)
        {
            _citiesQuest.CompleteQuestCondition();
            return;
        }
    }

    private void SoldierQuestCondition()
    {
        UnitsManager unitsManager = _player.GetComponent<UnitsManager>();
        Soldier soldier;
        for (int i = 0; i < unitsManager.GameUnits.Count; i++)
        {
            if (unitsManager.GameUnits[i].TryGetComponent<Soldier>(out soldier))
            {
                _soldierQuest.CompleteQuestCondition();
                return;
            }
        }
    }
}
