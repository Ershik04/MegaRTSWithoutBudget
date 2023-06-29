using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _position;

    private void Update()
    {
        
    }

    public void MoveUnit(GameUnit gameUnit)
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
            gameUnit.transform.position = Vector3.MoveTowards(gameUnit.transform.position, mouse * _speed * Time.deltaTime, 100);
        }
    }
}
