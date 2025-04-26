using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private RoomListing roomListingPrefab;

    private List<RoomListing> roomListings = new List<RoomListing>();

    private RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }
    public override void OnJoinedRoom()
    {
        _roomsCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList) 
        {
            if(info.RemovedFromList)
            {
                int index = roomListings.FindIndex(x => x._RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(roomListings[index].gameObject);
                    roomListings.RemoveAt(index);
                }
            }
            else
            {
                RoomListing listing = Instantiate(roomListingPrefab, content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    roomListings.Add(listing);
                }
            }

        }
    }
}
