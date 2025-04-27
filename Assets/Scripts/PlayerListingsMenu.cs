using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private PlayerListing _playerListingPrefab;

    private List<PlayerListing> roomListings = new List<PlayerListing>();

    private RoomsCanvases _roomsCanvases;
    public void FirstInicialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();

    }
    public override void OnDisable()
    {
        base.OnDisable();
        for(int i = 0; i < roomListings.Count; i++)
            Destroy(roomListings[i].gameObject);
        roomListings.Clear();

    }
    private void GetCurrentRoomPlayers()
    {
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    private void AddPlayerListing(Player player)
    {
        int index = roomListings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            roomListings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListingPrefab, content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                roomListings.Add(listing);
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = roomListings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(roomListings[index].gameObject);
            roomListings.RemoveAt(index);
        }
    }

    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //for (int i = 0; i < roomListings.Count; i++)
            //{
            //    if (roomListings[i].Player != PhotonNetwork.LocalPlayer)
            //    {
            //        if (!roomListings[i].Ready)
            //            return;
                    
            //    }
            //}
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);

        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = roomListings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            roomListings[index].Ready = ready;
        }
    }
}