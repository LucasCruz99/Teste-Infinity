using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;

public class GameConnetic : MonoBehaviourPunCallbacks
{
    #region Variable
    public Text Log;
    public bool NaSala;
    public static GameConnetic instace;
    #endregion

    #region Awake
    private void Awake()
    {
        instace = this;
        Log.text = " Conectando...";
        PhotonNetwork.NickName = "Lucas" + Random.Range(10, 1000);
    }
    #endregion

    #region OnOnConnectedToMaster
    public override void OnConnectedToMaster()
    {
        Log.text += "\n Procurando Looby";
        if (PhotonNetwork.InLobby == false)
        {
            Log.text += "\n Entrando no Looby";
            PhotonNetwork.JoinLobby();
        }
    }
    #endregion

    #region OnJoinedLobby
    public override void OnJoinedLobby()
    {
        Log.text += "\n Conectado ao looby";
        Log.text += "\n procurando sala";
    }
    #endregion

    #region OnJoinRoomFailed
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Log.text += "\n Sala nao existe, Criando...";
        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            Log.text += "\n Sala Criada";
            PhotonNetwork.CreateRoom("Infinty_teste");
            RoomOptions room = new RoomOptions { MaxPlayers = 20 };

        }
    }
    #endregion

    #region OnJoinedRoom
    public override void OnJoinedRoom()
    {
        Log.text += "\n Voce está conectado";
        NaSala = true;
        PhotonNetwork.Instantiate("Personagens", Vector3.zero, Quaternion.identity);
        LimpaLog();

    }
    #endregion

    #region LimpaLog
    async void LimpaLog()
    {
        await Task.Delay(2500);
        Log.text = null;
    }
    #endregion

    #region OnPlayerEnteredRoom
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Log.text += "\n Um Jogador entrou";
        base.OnPlayerEnteredRoom(newPlayer);
    }
    #endregion
}
