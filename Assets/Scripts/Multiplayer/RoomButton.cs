using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _buttonText;
    private RoomInfo _info;

    public void SetButtonDetails(RoomInfo inputInfo)
    {
        _info = inputInfo;
        _buttonText.text = _info.Name;
    }

    public void OpenRoom()
    {
        Launcher.Instance.JoinRoom(_info);
    }
}
