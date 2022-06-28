using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody PlayerRigidbody;
    public float Vel;
    public GameObject Look;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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

        PlayerRigidbody.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Vel;
        PlayerRigidbody.transform.LookAt(Look.transform, Look.transform.up);

        if (Physics.Raycast(ray, out raycastHit))
            Look.transform.position = raycastHit.point;

    }

    void SetAnimation()
    {




    }
}
