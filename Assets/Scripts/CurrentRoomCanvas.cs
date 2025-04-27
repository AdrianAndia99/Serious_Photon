using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField] private PlayerListingsMenu _playerListingsMenu;
    [SerializeField] private LeaveRoomMenu _leaveRoomMenu;
    public LeaveRoomMenu LeaveRoomMenu {get { return _leaveRoomMenu; } }

    private RoomsCanvases _roomsCanvases;
    public void FirstInicialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInicialize(canvases);
        _leaveRoomMenu.FirstInicialize(canvases);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
