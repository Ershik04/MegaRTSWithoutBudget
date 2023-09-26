using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField]
    private GameObject _loadingScreen;
    [SerializeField]
    private TMP_Text _loadingText;

    [SerializeField]
    private GameObject _menuButtons;

    [SerializeField]
    private GameObject _createRoomScreen;
    [SerializeField]
    private TMP_InputField _roomNameInput;

    [SerializeField]
    private GameObject _roomBrowsingPanel;
    [SerializeField]
    private List<RoomButton> _allRoomButtons = new List<RoomButton>();
    [SerializeField]
    private RoomButton _theRoomButton;

    [SerializeField]
    private GameObject _errorScreen;
    [SerializeField]
    private TMP_Text _errorText;

    private int _maxPlayers;

    private string _connectingText = "Connecting to network...";
    private string _connectingToLobby = "Connecting to lobby...";
    private string _roomText = "Creating room...";
    private string _failedText = "Failed to create room";
    private string _joiningRoomText = "Joining room";

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CloseMenu();
        _loadingScreen.SetActive(true);
        _loadingText.text = _connectingText;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void CloseMenu()
    {
        _loadingScreen.SetActive(false);
        _menuButtons.SetActive(false);
        _createRoomScreen.SetActive(false);
        _roomBrowsingPanel.SetActive(false);
        _errorScreen.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        _loadingText.text = _connectingToLobby;
    }

    public override void OnJoinedLobby()
    {
        CloseMenu();
        _menuButtons.SetActive(true);
    }

    public void OpenRoomCreate()
    {
        CloseMenu();
        _createRoomScreen.SetActive(true);
    }

    public void OpenRoomBrowser()
    {
        CloseMenu();
        _roomBrowsingPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        CloseMenu();
        _menuButtons.SetActive(true);
    }

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(_roomNameInput.text))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = _maxPlayers;
            PhotonNetwork.CreateRoom(_roomNameInput.text, options);
            CloseMenu();
            _loadingText.text = _roomText;
            _loadingScreen.SetActive(true);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        _errorText.text = _failedText + ". " + message;
        CloseMenu();
        _errorScreen.SetActive(true);
    }

    public void JoinRoom(RoomInfo inputInfo)
    {
        PhotonNetwork.JoinRoom(inputInfo.Name);
        CloseMenu();
        _loadingText.text = _joiningRoomText;
        _loadingScreen.SetActive(true);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomButton rb in _allRoomButtons)
        {
            Destroy(rb.gameObject);
        }
        _allRoomButtons.Clear();
        for (int i = 0; i < roomList.Count; i++)
        {

        }
    }
}
