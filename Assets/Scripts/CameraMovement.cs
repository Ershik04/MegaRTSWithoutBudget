using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraMovement : MonoBehaviour, IPunObservable
{
    [SerializeField]
    private float _moveSpeed;

    private PhotonView _photonView;
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            Move();
            CameraZoom();
        } 
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _moveSpeed;
        }
    }

    private void CameraZoom()
    {
        if (Input.mouseScrollDelta == Vector2.up)
        {
            transform.position += Vector3.down;
        }
        else if (Input.mouseScrollDelta == Vector2.down)
        {
            transform.position += Vector3.up;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
    }
}
