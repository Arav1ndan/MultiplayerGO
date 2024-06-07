using UnityEngine;
using Photon.Pun;
using Cinemachine;
using Unity.Mathematics;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    [Space]
    public GameObject CamreaPrefab;
    [Space]
    //public GameObject Enemy;
    [Space]
    public Transform SpawnPoint;
    public Transform EnemySpawnPoint;
    // Start is called before the first frame update
    /*void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to server");

        PhotonNetwork.JoinLobby();
        
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("We are in the lobby");
        PhotonNetwork.JoinOrCreateRoom("test",null,null);
      
    }*/
    public override void OnJoinedRoom()
    {
        
        Debug.Log("We are connected and in a room");
        GameObject _player = PhotonNetwork.Instantiate(player.name, SpawnPoint.position, Quaternion.identity);
        if (_player == null)
        {
            Debug.LogError("Failed to instantiate player object");
        }
        GameObject _Camera = PhotonNetwork.Instantiate(CamreaPrefab.name, SpawnPoint.position, Quaternion.identity);
        CinemachineVirtualCamera _vcam = _Camera.GetComponent<CinemachineVirtualCamera>();
        CinemachineTransposer transposer = _vcam.GetCinemachineComponent<CinemachineTransposer>();
        _vcam.LookAt = _player.transform;
        _vcam.Follow = _player.transform;
        //GameObject enemy = PhotonNetwork.Instantiate(Enemy.name,EnemySpawnPoint.position,Quaternion.identity);
      
        
    }
}
