using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    #region Variable
    Rigidbody ZumbiRigidbody;
    Vector3 PlayerDir;
    public float vel;
    public static Zumbi instance;
    #endregion

    private void Awake()
    {
        instance = this;
    }


    #region start
    void Start()
    {
        ZumbiRigidbody = GetComponent<Rigidbody>();
    }
    #endregion

    #region Update
    void Update()
    {
        FollowPlayer();
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
}
