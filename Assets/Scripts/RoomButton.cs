using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomButton : MonoBehaviour
{
    public TMP_Text buttontext;
    private RoomInfo info;
    public void SetButtonDetails(RoomInfo inputInfo)
    {
        info = inputInfo;
        buttontext.text = info.Name;
    }
    public void OpenRoom()
    {
        Launcher.instance.JoinRoom(info);
    }
}
