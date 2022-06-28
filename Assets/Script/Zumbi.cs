using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    Rigidbody ZumbiRigidbody;
    Vector3 PlayerDir;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        ZumbiRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {

        ZumbiRigidbody.transform.LookAt(Player.instance.transform.position, Player.instance.transform.up);
        PlayerDir = Player.instance.transform.position - transform.position;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + PlayerDir.normalized * vel * Time.deltaTime);

    }
}
