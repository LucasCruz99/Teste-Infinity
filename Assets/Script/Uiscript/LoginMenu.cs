using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    #region Variable
    public GameObject game_menu;
    public GameObject Looby;
    public GameObject Login_menu;
    public Text PlayerList;
    #endregion

    #region GameMenu
    public void GameMenu()
    {
        game_menu.SetActive(true);
        Login_menu.SetActive(false);
    }
    #endregion

    #region StarGame
    public void StarGame()
    {
        SceneManager.LoadSceneAsync("Fase1", LoadSceneMode.Single);
        game_menu.gameObject.SetActive(false);
    }
    #endregion

    #region Multiplayer
    public void Multiplayer()
    {
        PhotonNetwork.ConnectUsingSettings();
        game_menu.gameObject.SetActive(false);
        Looby.gameObject.SetActive(true);

        foreach (var item in PhotonNetwork.PlayerList)
        {
            PlayerList.text += "\n" + item.NickName;
            Debug.Log(item.NickName);
        }
    }
    #endregion

    #region GameConneticButton
    public void GameConneticButton()
    {
        PhotonNetwork.JoinRoom("Infinty_teste");
        SceneManager.LoadSceneAsync("Fase1", LoadSceneMode.Single);
        game_menu.gameObject.SetActive(false);
    }
    #endregion

    #region Quit
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
