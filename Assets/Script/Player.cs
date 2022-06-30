using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variable
    Rigidbody PlayerRigidbody;
    public float Vel;
    public GameObject Look;
    public GameObject Smg;
    public GameObject Desert;
    public GameObject ArmaDePregos;
    public GameObject Revolve;
    public static Player instance;
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
        PlayerRigidbody = GetComponent<Rigidbody>();
        Desert.SetActive(true);
    }
    #endregion

    #region Update
    void Update()
    {
        Shot();

    }
    #endregion

    #region FixeUpdate
    private void FixedUpdate()
    {
        Movimento();
    }
    #endregion

    #region Movimento
    void Movimento()
    {
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Vel * Time.deltaTime);
    }
    #endregion

    #region SetAnimation
    void SetAnimation()
    {




    }
    #endregion

    #region Shot
    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        PlayerRigidbody.transform.LookAt(new Vector3(Look.transform.position.x, 0, Look.transform.position.z), Look.transform.up);
        if (Physics.Raycast(ray, out raycastHit))
        {
            Look.transform.position = raycastHit.point;
            if (raycastHit.collider.tag == "Inimigo" && Input.GetMouseButtonUp(0))
            {
                raycastHit.collider.gameObject.SetActive(false);
            }
        }


    }
    #endregion
}
