using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    private RoomsCanvases _roomsCanvases;
    public void FirstInicialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
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
