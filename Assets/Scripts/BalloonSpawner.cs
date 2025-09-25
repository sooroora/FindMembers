using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  풍선을 소환하는 스포너입니다.
 *  준영님이 만들어두신 BalloonMover 를 사용할 수 있게 작성했습니다.
 */
public class BalloonSpawner : MonoBehaviour
{
    // 풍선 스프라이트를 프리팹으로 만든 것을 인스펙터에서 설정해줍니다.
    [SerializeField]  GameObject balloonPrefab;
    
    private float nowDelay;
    
    void Start()
    {
        nowDelay = Random.Range(0.2f, 0.5f);
    }

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
        
        GameObject balloon = Instantiate(this.balloonPrefab, spawnPos, Quaternion.identity);
        BalloonMover spawnedBaloon = balloon.AddComponent<BalloonMover>();
        spawnedBaloon.moveSpeed = Random.Range(3.0f, 10.0f);
        spawnedBaloon.swaySpeed = Random.Range(3.0f, 5.0f);
        
        Destroy(balloon, 6f);
    }
}
