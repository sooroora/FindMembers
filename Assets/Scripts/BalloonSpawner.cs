using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 *  풍선을 소환하는 스포너입니다.
 *  준영님이 만들어두신 BalloonMover 를 사용할 수 있게 작성했습니다.
 */
public class BalloonSpawner : MonoBehaviour
{
    // 풍선 스프라이트를 프리팹으로 만든 것을 인스펙터에서 설정해줍니다.
    [SerializeField]  GameObject balloonPrefab;
    

    // 랜덤 딜레이의 최소, 최대값을 설정합니다.
    public float delayMin = 0.2f;
    public float delayMax = 0.5f;

    void Start()
    {
        if (GameManager.Instance.currentLevel == 3)
            StartSpawning();
    }
    void SpawnBalloon()
    {
        // 스폰 위치 설정
        float randomX = Random.Range(-3f, 3f);
        Vector3 spawnPos = new Vector3(randomX, -6f, 0f);
        
        // 스폰
        GameObject balloon = Instantiate(this.balloonPrefab, spawnPos, Quaternion.identity);
        
        // 스폰한 풍선에 준영님이 작성한 BalloonMover 를 달아줍니다.
        BalloonMover spawnedBaloon = balloon.AddComponent<BalloonMover>();
        
        // 풍선이 올라가는 스피드를 설정합니다.
        // 마구 올라가는 풍선의 느낌을 주기 위해 역시 랜덤으로 설정해 줍니다.
        spawnedBaloon.moveSpeed = Random.Range(3.0f, 10.0f);
        spawnedBaloon.swaySpeed = Random.Range(3.0f, 5.0f);
        
        // 풍선은 6초 뒤에 제거합니다.
        Destroy(balloon, 6f);
    }
    
    Coroutine spawnBalloonCoroutine;
    public void StartSpawning()
    {
        if (spawnBalloonCoroutine == null)
        {
            spawnBalloonCoroutine = StartCoroutine(DelayBalloonSpawn());
        }
        else
        {
            StopSpawning();
            spawnBalloonCoroutine = StartCoroutine(DelayBalloonSpawn());
        }
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnBalloonCoroutine);
    }
    IEnumerator DelayBalloonSpawn()
    {
        while (true)
        {
            float delay = Random.Range(delayMin, delayMax);
            
            yield return new WaitForSeconds(delay);
            
            // 풍선을 스폰합니다.
            SpawnBalloon();
        }
    }
}
