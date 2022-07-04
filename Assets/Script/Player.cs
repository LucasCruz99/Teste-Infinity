using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

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
    public PhotonView PhotonView;
    public LineRenderer Line;
    public GameObject MyAvatar;
    CinemachineVirtualCamera VirtualCamera;
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
        if (PhotonView.IsMine)
        {
            VirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            VirtualCamera.Follow = transform;
        }
       



    }
    #endregion

    #region Update
    void Update()
    {
        if (PhotonView.IsMine)
        {
            if (gameManager.instance.GameOuver) return;
            // Debug.Log(Life);
            target();
            SetAnimation();

        }
    }
    #endregion

    #region FixeUpdate
    private void FixedUpdate()
    {
        if (gameManager.instance.GameOuver) return;
        if (PhotonView.IsMine)
            Movimento();
    }
    #endregion

    #region Movimento
    void Movimento()
    {
        Input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + Input * Vel * Time.deltaTime);

        if (Input != Vector3.zero)
            transform.forward = Input;
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

        Ray ray = new Ray(Look.transform.position, Look.transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
            Line.SetPosition(1, new Vector3(0, 0, raycastHit.point.x));

        if (Physics.Raycast(ray, out raycastHit) && NewShot == true && UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Shot(raycastHit, ray);

        }
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
