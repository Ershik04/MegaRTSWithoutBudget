using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    [SerializeField]
    private bool _selected;
    [SerializeField]
    private int _number;
    [SerializeField]
    private float _moveTime;
    [SerializeField]
    private float _maxMoveTime;
    private bool _canStartMove = false;
    private Transform _tile;

    public bool Selected => _selected;
    public int Number => _number;

    private void Update()
    {
        if (_moveTime > 0)
        {
            _moveTime -= Time.deltaTime;
        }
        MoveUnit();
    }

    public void SelectUnit()
    {
        _selected = true;
    }

    public void SetMaxMoveTime(Transform tile)
    {
        _tile = tile;
        Vector3 position = new Vector3(_tile.transform.position.x, 0, _tile.transform.position.z);
        float distanceToPosition = Vector3.Distance(transform.position, position);
        _moveTime = _maxMoveTime * distanceToPosition / 10;
        _canStartMove = true;
    }

    public void MoveUnit()
    {
        if (_moveTime <= 0 && _canStartMove)
        {
            Vector3 position = new Vector3(_tile.transform.position.x, 0, _tile.transform.position.z);
            gameObject.transform.position = position;
        }
    }
}
