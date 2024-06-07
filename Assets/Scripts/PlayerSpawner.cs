using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    private GameObject player;

    void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }
    public void SpawnPlayer()
    {
        Transform spawnPoint = SpawnManager.instance.GetSpawnPoint();

        player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        GameObject _Camera = PhotonNetwork.Instantiate(cameraPrefab.name, player.transform.position, Quaternion.identity);
        _Camera.transform.parent = player.transform;
        CinemachineVirtualCamera _vcam = _Camera.GetComponent<CinemachineVirtualCamera>();
        CinemachineTransposer transposer = _vcam.GetCinemachineComponent<CinemachineTransposer>();
       
        _vcam.LookAt = player.transform;
        _vcam.Follow = player.transform;
    }
}   
