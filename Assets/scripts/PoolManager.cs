using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject particle = null;
    [SerializeField]
    private GameObject gostWisp = null;

    [SerializeField]
    private int particleLength = 20;
    [SerializeField]
    private int gostWispLength = 20;

    public static PoolManager instance = null;

    public Queue<GameObject> particlePool = new Queue<GameObject>();
    public Queue<GameObject> gostWispPool = new Queue<GameObject>();

    public enum PoolType
    {
        PARTICLE,
        WISP
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);

        for (int i = 0; i < particleLength; i++)
        {
            GameObject obj = Instantiate(particle, transform);
            particlePool.Enqueue(obj);
            obj.SetActive(false);
        }

        for (int i = 0; i < gostWispLength; i++)
        {
            GameObject obj = Instantiate(gostWisp, transform);
            gostWispPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    public void InsertQueue(GameObject obj, PoolType poolType)
    {
        switch (poolType)
        {
            case PoolType.PARTICLE:
                particlePool.Enqueue(obj);
                obj.SetActive(false);
                break;
            case PoolType.WISP:
                gostWispPool.Enqueue(obj);
                obj.SetActive(false);
                break;
        }
    }

    public GameObject GetQueue(PoolType poolType)
    {
        GameObject obj = null;

        switch (poolType)
        {
            case PoolType.PARTICLE:
                obj = particlePool.Dequeue();
                obj.SetActive(true);
                return obj;
            case PoolType.WISP:
                obj = gostWispPool.Dequeue();
                obj.SetActive(true);
                return obj;
        }

        return obj;
    }
}
