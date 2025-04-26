using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField] private CreateRoomMenu _createRoomMenu;
    [SerializeField] private RoomListingsMenu _roomListingsMenu;

    private RoomsCanvases _roomsCanvases;
    public void FirstInicialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInicialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }
}
