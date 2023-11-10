using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private Transform _playerCamera;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        var player = PhotonNetwork.Instantiate(_playerPrefab.name, transform.position, Quaternion.identity);
        _playerCamera.SetParent(player.transform.GetChild(0));
        _playerCamera.transform.localPosition = Vector3.zero;
        _playerCamera.transform.localRotation = Quaternion.identity;
    }
}
