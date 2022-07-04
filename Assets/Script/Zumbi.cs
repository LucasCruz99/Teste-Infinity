using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Zumbi : MonoBehaviour
{
    #region Variable
    Rigidbody ZumbiRigidbody;
    Vector3 PlayerDir;
    public float vel;
    public static Zumbi instance;
    Animator Animator;
    #endregion

    #region Awake
    private void Awake()
    {
        instance = this;
        Animator = GetComponent<Animator>();
    }
    #endregion

    #region start
    void Start()
    {
        ZumbiRigidbody = GetComponent<Rigidbody>();
    }
    #endregion

    #region Update
    void Update()
    {
        if (gameManager.instance.GameOuver) return;
        if (Player.instance == null) return;


        FollowPlayer();
        Atack();


    }
    #endregion

    #region FollowPlayer
    void FollowPlayer()
    {

        ZumbiRigidbody.transform.LookAt(Player.instance.transform.position, Player.instance.transform.up);
        PlayerDir = Player.instance.transform.position - transform.position;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + PlayerDir.normalized * vel * Time.deltaTime);

    }
    #endregion

    #region Attack
    void Atack()
    {
        PlayerDir = Player.instance.transform.position - transform.position;

        if (Vector3.Distance(Player.instance.transform.position, transform.position) < 3)
            Animator.SetBool("Ataque", true);
        else
            Animator.SetBool("Ataque", false);

    }
    #endregion

    #region Dano
    void Dano()
    {
        if (Player.instance.PhotonView.IsMine)
        {
            if (Vector3.Distance(Player.instance.transform.position, transform.position) <= 2.5f)
                Player.instance.Life -= 25;

        }

    }
    #endregion
}
