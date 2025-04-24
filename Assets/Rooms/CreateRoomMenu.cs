using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI roomNameText;

    public void OnClick_CreateRoom()
    {
        if(!PhotonNetwork.IsConnected)
            return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(roomNameText.text,options,TypedLobby.Default);

    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Lobby Created", this);// si vemos otro mastermanager.addtex...
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed " + message, this);// si vemos otro mastermanager.addtex...
    }
}
