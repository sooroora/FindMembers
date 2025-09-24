using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public GameObject successUI;
    public float spawnTime = 2f;
    public float moveSpeed = 2f;
    
    void Start()
    {
        InvokeRepeating("SpawnBalloon", 0f, spawnTime);
    }
    void SpawnBalloon()
    {
        float randomX = Random.Range(-3f, 3f);

        Vector3 spawnPos = new Vector3(randomX, -6f, 0f);

        GameObject balloon = Instantiate(balloonPrefab, spawnPos, Quaternion.identity);
        balloon.AddComponent<BalloonMover>().moveSpeed = moveSpeed;
        Destroy(balloon, 6f);
    }
}

public class BalloonMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
