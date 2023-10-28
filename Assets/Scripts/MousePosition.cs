using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameUnit gameUnit = _player.GetComponent<ChooseUnit>().ChoosedUnit;
        if (gameUnit != null)
        {
            gameUnit.SetMaxMoveTime(gameObject.transform);
        }
    }
}
