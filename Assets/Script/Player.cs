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
    Vector3 Inputt;
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

        if (PhotonView.IsMine || gameManager.instance.SiglePlayer)
        {
            VirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            VirtualCamera.Follow = transform;
        }
    }
    #endregion

    #region Update
    void Update()
    {
        if (PhotonView.IsMine || gameManager.instance.SiglePlayer)
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
        if (PhotonView.IsMine || gameManager.instance.SiglePlayer)
            Movimento();
    }
    #endregion

    #region Movimento
    void Movimento()
    {
        Inputt = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + Inputt * Vel * Time.deltaTime);

        //  if (Inputt != Vector3.zero)
        //      transform.forward = Inputt;
    }
    #endregion

    #region SetAnimation
    void SetAnimation()
    {
        if (Inputt != Vector3.zero)
            PlayerAnimator.SetBool("Correr", true);
        else
            PlayerAnimator.SetBool("Correr", false);
    }
    #endregion

    #region Target
    void target()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (Vector3.Distance(raycastHit.point, transform.position) > 2)
                transform.LookAt(new Vector3(raycastHit.point.x, 0, raycastHit.point.z), Vector3.up);



        }

        if (Physics.Raycast(ray, out raycastHit) && NewShot == true && UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
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
