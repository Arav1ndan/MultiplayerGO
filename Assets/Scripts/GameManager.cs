using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun.Demo.PunBasics;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    public GameObject OptionScreen;
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
      
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideOption();
        }
        if(OptionScreen.activeInHierarchy && !Cursor.visible){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void ShowHideOption()
    {
        if(!OptionScreen.activeInHierarchy)
        {
            OptionScreen.SetActive(true);
        }else{
            OptionScreen.SetActive(false);
        }
    }
    public void OnExitToMainMenu()
    { 
       PhotonNetwork.AutomaticallySyncScene = false;
       PhotonNetwork.LeaveRoom();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
