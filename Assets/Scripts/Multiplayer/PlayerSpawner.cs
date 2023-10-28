using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    private GameObject _player;
    public static PlayerSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

    private void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        Vector3 spawnpoint = new Vector3(5f, 20f, 5f);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        _player = PhotonNetwork.Instantiate(_playerPrefab.name, spawnpoint, rotation);
    }
}
