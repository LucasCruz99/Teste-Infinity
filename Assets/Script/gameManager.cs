using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.IO;

public class gameManager : MonoBehaviourPunCallbacks
{
    #region Variable
    public GameObject Respawn_1, Respawn_2;
    public static gameManager instance;
    public int NzumbiInicio;
    public bool GameOuver;
    int NPlayer;
    public string LocalPlayer;
    bool zum;
    public bool SiglePlayer;
    public GameObject PlayerObject;
    #endregion

    #region Awake
    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region Start
    void Start()
    {
        RespawPlayer();

        if (GameConnetic.instace.NaSala == false) return;

        photonView.RPC("addPlayer", RpcTarget.AllBuffered);

    }
    #endregion

    #region Update
    void Update()
    {
        if (GameConnetic.instace.NaSala == false) return;

        if (zum == false)
            Respawn();
    }
    #endregion

    #region Respaw
    public async void Respawn()
    {
        zum = true;
        await Task.Delay(2000);
        for (int i = 0; i < NzumbiInicio;)
        {
            if (gameManager.instance.GameOuver || Application.isPlaying == false) break;
            Respawn_1.GetComponent<Pool>().respawn("Zumbi", Respawn_1.transform).transform.GetChild(Random.Range(1, 27)).gameObject.SetActive(true);
            await Task.Delay(2000);
            if (gameManager.instance.GameOuver || Application.isPlaying == false) break;
            Respawn_2.GetComponent<Pool>().respawn("Zumbi", Respawn_2.transform).transform.GetChild(Random.Range(1, 27)).gameObject.SetActive(true);
            await Task.Delay(2000);
            i++;
        }
    }
    #endregion

    #region AddPlayer
    [PunRPC]
    void addPlayer()
    {
        CreatPlayer();
    }
    #endregion

    #region CreatPlayer
    void CreatPlayer()
    {
        PhotonNetwork.Instantiate("Personagens", Vector3.zero, Quaternion.identity);
    }
    #endregion

    #region RespawPlayer
    async void RespawPlayer()
    {
        GameConnetic.instace.Log.text = null;
        await Task.Delay(500);
        if (PhotonNetwork.IsConnected == false)
        {
            Instantiate(PlayerObject);
            SiglePlayer = true;
        }
        Respawn();
    }
    #endregion
}
