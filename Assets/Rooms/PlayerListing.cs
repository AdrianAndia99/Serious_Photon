using UnityEngine;
using Photon.Realtime;
using TMPro;
public class PlayerListing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roomNameText;

    public Player Player { get; private set; }
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        roomNameText.text = player.NickName;
    }
}
