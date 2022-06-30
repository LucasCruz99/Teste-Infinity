using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    #region Variable
    Rigidbody PlayerRigidbody;
    Animator PlayerAnimator;
    public float Vel;
    public int Life;
    Vector3 Input;
    public GameObject Look;
    public GameObject Smg;
    public GameObject Desert;
    public GameObject ArmaDePregos;
    public GameObject Revolve;
    public static Player instance;
    [HideInInspector]
    public int Pontos;
    public int DelayShot;
    bool NewShot;
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
        PlayerAnimator = GetComponent<Animator>();
        NewShot = true;
        Life = 100;
        Desert.SetActive(true);
    }
    #endregion

    #region Update
    void Update()
    {
        if (gameManager.instance.GameOuver) return;
        Debug.Log(Life);
        target();
        SetAnimation();
    }
    #endregion

    #region FixeUpdate
    private void FixedUpdate()
    {
        if (gameManager.instance.GameOuver) return;
        Movimento();
    }
    #endregion

    #region Movimento
    void Movimento()
    {

        Input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + Input * Vel * Time.deltaTime);
    }
    #endregion

    #region SetAnimation
    void SetAnimation()
    {
        if (Input != Vector3.zero)
            PlayerAnimator.SetBool("Correr", true);
        else
            PlayerAnimator.SetBool("Correr", false);
    }
    #endregion

    #region Target
    void target()
    {
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        RaycastHit raycastHit;

        PlayerRigidbody.transform.LookAt(new Vector3(Look.transform.position.x, 0, Look.transform.position.z), Look.transform.up);

        if (Physics.Raycast(ray, out raycastHit))
            Look.transform.position = raycastHit.point;

        if (NewShot == true && UnityEngine.Input.GetMouseButtonUp(0))
            Shot(raycastHit, ray);


    }
    #endregion

    #region Shot
    async void Shot(RaycastHit RaycastHit, Ray ray)
    {

        if (Physics.Raycast(ray, out RaycastHit))
        {
            if (RaycastHit.collider.tag == "Inimigo")
            {
                RaycastHit.collider.gameObject.SetActive(false);
                Pontos++;
            }
        }
        NewShot = false;

        await Task.Delay(DelayShot * 1000);
        NewShot = true;
    }
    #endregion
}
