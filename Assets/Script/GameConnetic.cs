using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class GameConnetic : MonoBehaviourPunCallbacks
{
    public Text Log;
    public bool NaSala;
    public static GameConnetic instace;

    private void Awake()
    {
        instace = this;
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
            Log.text += "\nConectado...";
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Log.text += "\nConectado ao looby";
        Log.text += "\nConectando a sala";
        PhotonNetwork.JoinRoom("Infinty_teste");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Log.text = "/nSala nao existe,Criando";
        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            Log.text = "/nSalaCriada";
            PhotonNetwork.CreateRoom("Infinty_teste");
            RoomOptions room = new RoomOptions { MaxPlayers = 20 };

        }
    }

    public override void OnJoinedRoom()
    {
        Log.text = "/n voce está conctado";
        NaSala = true;
        PhotonNetwork.Instantiate("Personagens", Vector3.zero, Quaternion.identity);

    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Log.text = "/n um player entrou";
        ///PhotonNetwork.Instantiate("Personagens", Vector3.zero, Quaternion.identity);
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
