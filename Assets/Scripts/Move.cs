using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviourPunCallbacks
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
        Moving();
    }

    private void Moving()
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
}
