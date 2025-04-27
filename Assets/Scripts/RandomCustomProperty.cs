using UnityEngine;
using TMPro;
using Photon.Pun;
public class RandomCustomProperty : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();


    private void SetCustomNumber()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, 99);

        _text.text = randomNumber.ToString();
        customProperties["RandomNumber"] = randomNumber;
        PhotonNetwork.SetPlayerCustomProperties(customProperties);
        //PhotonNetwork.LocalPlayer.CustomProperties = customProperties;
    }

    public void OnClick_Button()
    {
        SetCustomNumber();
    }
}
