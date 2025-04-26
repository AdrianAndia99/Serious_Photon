using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.Collections.LowLevel.Unsafe;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private PlayerListing _playerListingPrefab;

    private List<PlayerListing> roomListings = new List<PlayerListing>();

    private void Awake()
    {
        
    }
    private void GetCurrentRoomPlayers()
    {
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(_playerListingPrefab, content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            roomListings.Add(listing);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
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
}