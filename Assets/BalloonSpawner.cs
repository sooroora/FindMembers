using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField]  GameObject failBalloon;
    private float nowDelay;
    
    void Start()
    {
        nowDelay = Random.Range(0.2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        nowDelay -= Time.deltaTime;

        if (nowDelay <= 0)
        {
            SpawnBalloon();
            nowDelay = Random.Range(0.2f, 0.5f);
        }
    }

    void SpawnBalloon()
    {
        float randomX = Random.Range(-3f, 3f);
        Vector3 spawnPos = new Vector3(randomX, -6f, 0f);
        
        GameObject balloon = Instantiate(failBalloon, spawnPos, Quaternion.identity);
        BalloonMover spawnedBaloon = balloon.AddComponent<BalloonMover>();
        spawnedBaloon.moveSpeed = Random.Range(3.0f, 10.0f);
        spawnedBaloon.swaySpeed = Random.Range(3.0f, 5.0f);
        
        Destroy(balloon, 6f);
    }
}
