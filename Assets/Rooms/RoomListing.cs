using UnityEngine;
using Photon.Realtime;
using TMPro;
using Photon.Pun;
public class RoomListing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roomNameText;
    public RoomInfo _RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _RoomInfo = roomInfo;
        roomNameText.text = "Max Players: " + roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(_RoomInfo.Name);
    }
}
