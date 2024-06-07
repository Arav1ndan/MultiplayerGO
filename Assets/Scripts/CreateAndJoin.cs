using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Cinemachine;
using Photon.Realtime;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField Input_Creat;
    public TMP_InputField Input_Join;
    public GameObject player;
    [Space]
    public GameObject CamreaPrefab;
    [Space]
    //public GameObject Enemy;
    [Space]
    public Transform SpawnPoint;
    //public Transform EnemySpawnPoint;

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(Input_Creat.text));
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 8;

            PhotonNetwork.CreateRoom(Input_Creat.text, roomOptions);
        }
       
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(Input_Join.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("TDM");
       /* Debug.Log("We are connected and in a room");
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
        //GameObject enemy = PhotonNetwork.Instantiate(Enemy.name,EnemySpawnPoint.position,Quaternion.identity);*/
    }
}
