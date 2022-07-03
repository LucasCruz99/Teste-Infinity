using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    #region Varible
    public Texture2D maouseCurso;
    public Text Pontos, Score1, Score2, Score3;
    public Slider SliderVida;
    public GameObject Panel;
    #endregion

    #region start
    void Start()
    {
        Cursor.SetCursor(maouseCurso, Vector2.zero, CursorMode.Auto);
    }
    #endregion

    #region Update
    void Update()
    {
        PontosMarcado();
        vida();
        GameOver();
    }
    #endregion

    #region Pontos marcados
    void PontosMarcado()
    {
        Pontos.text = Player.instance.Pontos.ToString();

        if (PlayerPrefs.GetInt("score1") < Player.instance.Pontos)
            PlayerPrefs.SetInt("score1", Player.instance.Pontos);
        else if (PlayerPrefs.GetInt("score2") < PlayerPrefs.GetInt("score1") && PlayerPrefs.GetInt("score2") > PlayerPrefs.GetInt("score3"))
        {
            PlayerPrefs.SetInt("score2", Player.instance.Pontos);
           
        }
        else if (PlayerPrefs.GetInt("score3") < PlayerPrefs.GetInt("score2") && PlayerPrefs.GetInt("score3") != PlayerPrefs.GetInt("score2"))
        {
            PlayerPrefs.SetInt("score3", Player.instance.Pontos);
           
        }

    }
    #endregion

    #region Vida
    public void vida()
    {
        SliderVida.value = Player.instance.Life;
    }
    #endregion

    #region GameOver
    public void GameOver()
    {
        if (Player.instance.Life == 0)
        {
            Panel.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Score1.text = PlayerPrefs.GetInt("score1").ToString();
            Score2.text = PlayerPrefs.GetInt("score2").ToString();
            Score3.text = PlayerPrefs.GetInt("score3").ToString();
            gameManager.instance.GameOuver = true;
        }
    }
    #endregion

    public void resart()
    {

        SceneManager.LoadScene("Fase1", LoadSceneMode.Single);
        Panel.SetActive(false);
    }
}
