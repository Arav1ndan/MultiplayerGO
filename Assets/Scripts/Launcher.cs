using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
   private static Launcher instance;
   private void Awake()
   {
        instance = this;
   }
    public GameObject loadingScreen;
    public TMP_Text loadingText;
    public GameObject menuButtons;
    public GameObject createRoomScreen;

    public TMP_InputField roomNameInput;
    public GameObject roomScreen;
    public TMP_Text roomNameText, playerNameLabel;
    public GameObject errorScreen;
    public TMP_Text errorText;
    
    void Start()
    {
        CloseMenus();

        loadingScreen.SetActive(true);
        loadingText.text = "Connecting to Network...";
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    void CloseMenus()
    {
        loadingScreen.SetActive(false);
        menuButtons.SetActive(false);
        createRoomScreen.SetActive(false);
        roomScreen.SetActive(false);
        errorScreen.SetActive(false);

    }
        public override void OnConnectedToMaster()
    {
        

        PhotonNetwork.JoinLobby();

        PhotonNetwork.AutomaticallySyncScene = true;

        loadingText.text = "Joining Lobby...";
    }
    public override void OnJoinedLobby()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }
    public void OpenRoomCreate()
    {
        CloseMenus();
        createRoomScreen.SetActive(true);
    }
    public void CreateRoom()
    {
        if(!string.IsNullOrEmpty(roomNameInput.text))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 8;

            PhotonNetwork.CreateRoom(roomNameInput.text, options);

            CloseMenus();
            loadingText.text = "Creating Room...";
            loadingScreen.SetActive(true);
        }
    }
    public override void OnJoinedRoom()
    {
        CloseMenus();
        roomScreen.SetActive(true);

        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed to Create Room :"+ message;
        CloseMenus();
        errorScreen.SetActive(true);
    }
    public void CloseErrorScreen()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        CloseMenus();
        loadingText.text = " Leaving Room ";
        loadingScreen.SetActive(true);
    }
}
