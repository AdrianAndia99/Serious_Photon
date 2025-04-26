using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField] private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas
    {
        get { return _createOrJoinRoomCanvas; }
    }

    [SerializeField] private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas
    {
        get { return _currentRoomCanvas; }
    }

    private void Awake()
    {
        FirstInicialize();
    }

    private void FirstInicialize()
    {
        CreateOrJoinRoomCanvas.FirstInicialize(this);
        CurrentRoomCanvas.FirstInicialize(this);
    }
}
