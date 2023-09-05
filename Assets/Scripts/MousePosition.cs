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
            Vector3 position = new Vector3(transform.position.x, 0, transform.position.y);
            gameUnit.MoveToPoint(position);
        }
    }
}
