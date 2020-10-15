using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowParticle : MonoBehaviour
{
    public GameObject particlePrefab = null;

    [SerializeField]
    private float defultTime = 0.154f;

    private Vector3 mousePos = Vector3.zero;
    private float spawnTime;
    private void Update()
    {
        if (Input.GetMouseButton(0) && spawnTime >= defultTime)
        {
            MakeParticle();
            spawnTime = 0;
        }
        spawnTime += Time.deltaTime;
    }
    private void MakeParticle()
    {
        mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        GameObject particlePrefab = PoolManager.instance.GetQueue(PoolManager.PoolType.PARTICLE);
        particlePrefab.transform.position = mousePos;
    }
}
