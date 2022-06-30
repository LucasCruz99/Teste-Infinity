using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class gameManager : MonoBehaviour
{
    public GameObject Respawn_1, Respawn_2;
    public static gameManager instance;
    public int NzumbiInicio;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Respawn();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void Respawn()
    {
        await Task.Delay(2000);

        for (int i = 0; i < NzumbiInicio;)
        {
            Respawn_1.GetComponent<Pool>().respawn("Zumbi", Respawn_1.transform).transform.GetChild(Random.Range(1, 27)).gameObject.SetActive(true);
            await Task.Delay(2000);
            Respawn_2.GetComponent<Pool>().respawn("Zumbi", Respawn_2.transform).transform.GetChild(Random.Range(1, 27)).gameObject.SetActive(true);
            await Task.Delay(2000);
            i++;
        }


    }
}
