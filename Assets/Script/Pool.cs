using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    #region AmountPool class
    [System.Serializable]
    public class AmountPool
    {
        public int Size;
        public string Tag;
        public GameObject Obj;
    }
    #endregion

    #region singleton

    public static Pool instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region Variable
    public List<AmountPool> pool = new List<AmountPool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    #endregion

    #region Start
    void Start()
    {
        foreach (AmountPool pools in pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i <= pools.Size; i++)
            {
                GameObject obj = Instantiate(pools.Obj);
                pools.Obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pools.Tag, objectPool);
        }
    }
    #endregion

    #region Respawn
    public GameObject respawn(string tag, Transform transform)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject objectRespawn = poolDictionary[tag].Dequeue();
        objectRespawn.SetActive(true);
        objectRespawn.GetComponent<Transform>().position = transform.position;
        poolDictionary[tag].Enqueue(objectRespawn);
        return objectRespawn;
    }
    #endregion

}
