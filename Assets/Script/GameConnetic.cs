using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameConnetic : MonoBehaviourPunCallbacks
{
    public Text Log;


    private void Awake()
    {
        Log.text = "Connetic";
        PhotonNetwork.LocalPlayer.NickName = "Lucas" + Random.Range(10, 1000);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Log.text += "\nConectado";

        if (PhotonNetwork.InLobby == false)
        {
            Log.text += "\nConectado";
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        Log.text += "\nConectado a uma sala";

        PhotonNetwork.JoinRoom("Infinty_Teste");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            Log.text = "/nSalaCriada";
            RoomOptions room = new RoomOptions { MaxPlayers = 20 };
            PhotonNetwork.CreateRoom("Infinty_teste", room, null);

        }
    }

    public override void OnJoinedRoom()
    {
        Log.text = "/n voce estar conctado";

        PhotonNetwork.Instantiate("Personagens", Vector3.zero, Quaternion.identity);
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
