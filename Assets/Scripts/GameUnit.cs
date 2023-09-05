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
    private float _speed;

    public bool Selected => _selected;
    public int Number => _number;


    public void SelectUnit()
    {
        _selected = true;
    }

    public void MoveToPoint(Vector3 position)
    {
        print(position);
        transform.position = Vector3.MoveTowards(transform.position, position * _speed * Time.deltaTime, 1);
    }
}
