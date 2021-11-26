using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe;
    public float height;
    public float spawnRate = 1;
    private float timer = 0;
    void Start()
    {
        PoolManager.instance.CreatePool(pipe, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnRate)
        {
            PoolManager.instance.ReuseObject(pipe, transform.position + new Vector3(0, Random.Range(-height, height), 0), Quaternion.identity);
            //newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
