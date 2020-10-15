using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject particle = null;


    [SerializeField]
    private int particleLength = 20;

    public static PoolManager current = null;

    public Queue<GameObject> particlePool = new Queue<GameObject>();

    private void Awake()
    {
        if (current == null)
        {
            current = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        for (int i = 0; i < particleLength; i++)
        {
            GameObject obj = Instantiate(particle, transform);
            particlePool.Enqueue(obj);
            obj.SetActive(false);
        }

    }

    public void InsertQueue(GameObject obj)
    {
        particlePool.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject obj = particlePool.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
