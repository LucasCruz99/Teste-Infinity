using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    #region Varible
    public Texture2D maouseCurso;
    public Text Pontos;
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
        Pontos.text = Player.instance.Pontos.ToString(); ;
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
            gameManager.instance.GameOuver = true;
        }
    }
    #endregion
}
