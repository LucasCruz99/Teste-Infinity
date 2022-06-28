using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject Respawn_1;
    public static gameManager instance;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Pool.instance.respawn("Zumbi", Respawn_1.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
