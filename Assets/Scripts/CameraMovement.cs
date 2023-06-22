using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private float _moveSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
        CameraZoom();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _camera.transform.position += Vector3.forward * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _camera.transform.position += Vector3.back * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _camera.transform.position += Vector3.right * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _camera.transform.position += Vector3.left * _moveSpeed;
        }
    }

    private void CameraZoom()
    {
        if (Input.mouseScrollDelta == Vector2.up)
        {
            _camera.transform.position += Vector3.down;
        }
        else if (Input.mouseScrollDelta == Vector2.down)
        {
            _camera.transform.position += Vector3.up;
        }
    }
}
