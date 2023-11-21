using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espawner : MonoBehaviour
{
    public Transform[] puntos_Spawns;
    public Transform prefab;
    int random=0;
    public float time = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 1.5f) time = time + Time.deltaTime;

        if (time >= 1.5f)
        {
            random = Random.Range(0, puntos_Spawns.Length - 1);
            Instantiate(prefab, puntos_Spawns[random].position, puntos_Spawns[random].rotation);
            time = 0f;
        }
        
    }
}
