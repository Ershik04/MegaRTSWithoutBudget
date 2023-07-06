using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    public void MoveUnit(GameUnit gameUnit)
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            var position = Camera.main.ScreenToWorldPoint(mouse);
            gameUnit.transform.position = Vector3.MoveTowards(gameUnit.transform.position, position * _speed * Time.deltaTime, 1);
        }
    }
}
