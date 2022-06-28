using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody PlayerRigidbody;
    public float Vel;
    public GameObject Look;
    public GameObject Smg;
    public GameObject Desert;
    public GameObject ArmaDePregos;
    public static Player instance;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {


    }
    private void FixedUpdate()
    {
        Movimento();
    }
    void Movimento()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        PlayerRigidbody.MovePosition(PlayerRigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Vel * Time.deltaTime);
        PlayerRigidbody.transform.LookAt(new Vector3(Look.transform.position.x, 0, Look.transform.position.z), Look.transform.up);

        if (Physics.Raycast(ray, out raycastHit))
            Look.transform.position = raycastHit.point;

    }

    void SetAnimation()
    {




    }
}
