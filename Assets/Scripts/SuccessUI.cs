using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessUI : MonoBehaviour
{
    public GameObject balloon;

    void Start()
    {
        NextSpawn();
    }

    void Update()
    {
        
    }

    void SpawnBalloon()
    {
        Instantiate(balloon);
    }

    void NextSpawn()
    {
        float delay = Random.Range(3f, 10f);
        Invoke("SpawnBalloon", delay);
    }
}
