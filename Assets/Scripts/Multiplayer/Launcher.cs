using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

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
    private GameObject _roomPanel;
    [SerializeField]
    private TMP_Text _roomNameText;
    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _errorScreen;
    [SerializeField]
    private TMP_Text _errorText;

    [SerializeField]
    private GameObject _inputScreen;
    [SerializeField]
    private TMP_InputField _nameInput;
    [SerializeField]
    private bool _hasSetNick;
    [SerializeField]
    private List<TMP_Text> _allPlayersName = new List<TMP_Text>();
    [SerializeField]
    private TMP_Text _playerNameLable;

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
        _roomPanel.SetActive(false);
        _errorScreen.SetActive(false);
        _inputScreen.SetActive(false);
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
        if (!_hasSetNick)
        {
            CloseMenu();
            _inputScreen.SetActive(true);
            if (PlayerPrefs.HasKey("playerName"))
            {
                _nameInput.text = PlayerPrefs.GetString("playerName");
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString(_nameInput.text);
            }
        }
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

    public override void OnJoinedRoom()
    {
        CloseMenu();
        _roomPanel.SetActive(true);
        _roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        ListAllPlayers();
        if (PhotonNetwork.IsMasterClient)
        {
            _startButton.SetActive(true);
        }
        else
        {
            _startButton.SetActive(false);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        TMP_Text newPlayerLable = Instantiate(_playerNameLable, _playerNameLable.transform.parent);
        newPlayerLable.text = newPlayer.NickName;
        newPlayerLable.gameObject.SetActive(true);
        _allPlayersName.Add(newPlayerLable);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        ListAllPlayers();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _startButton.SetActive(true);
        }
        else
        {
            _startButton.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        BackToMenu();
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
            RoomButton newButton = Instantiate(_theRoomButton, _theRoomButton.transform.parent);
            newButton.SetButtonDetails(roomList[i]);
            newButton.gameObject.SetActive(true);
            _allRoomButtons.Add(newButton);
        }
    }

    private void ListAllPlayers()
    {
        foreach (TMP_Text player in _allPlayersName)
        {
            Destroy(player.gameObject);
        }
        _allPlayersName.Clear();
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            TMP_Text newPlayerLable = Instantiate(_playerNameLable, _playerNameLable.transform.parent);
            newPlayerLable.text = players[i].NickName;
            newPlayerLable.gameObject.SetActive(true);
            _allPlayersName.Add(newPlayerLable);
        }
    }

    public void SetNickName()
    {
        if (!string.IsNullOrEmpty(_nameInput.text))
        {
            PhotonNetwork.NickName = _nameInput.text;
            PlayerPrefs.SetString("playerName", _nameInput.text);
            CloseMenu();
            _menuButtons.SetActive(true);
            _hasSetNick = true;
        }
    }
}
