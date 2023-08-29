using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    [SerializeField]
    private List<GameUnit> _gameUnits;

    public List<GameUnit> GameUnits => _gameUnits;

    public void AddUnitInOwn(GameUnit gameUnit)
    {
        _gameUnits.Add(gameUnit);
    }

    public void DeleteUnitFromOwn(GameUnit gameUnit)
    {
        _gameUnits.Remove(gameUnit);
    }

    public bool FindUnitInOwn(GameUnit gameUnit)
    {
        bool isPlayerUnit = false;
        for (int i = 0; i < _gameUnits.Count; i++)
        {
            if (_gameUnits[i] == gameUnit)
            {
                isPlayerUnit = true;
            }
        }
        return isPlayerUnit;
    }
}
