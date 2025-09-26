using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public GameObject successUI;
    public float spawnTime = 2f;    //생성 반복 간격
    public float moveSpeed = 2f;    //풍선 상승 속도
    
    private void Start()
    {
        InvokeRepeating("SpawnBalloon", 0f, spawnTime);     //풍선 생성 함수 반복
    }

    private void SpawnBalloon()
    {
        if (GameManager.Instance.currentLevel == 3) { }     //게임 난이도가 하드보다 높으면 실행
        else if (!successUI.activeSelf) return;             //성공UI가 켜져 있지 않은 경우 실행하지 않음

        float randomX = Random.Range(-3f, 3f);

        Vector3 spawnPos = new Vector3(randomX, -6f, 0f);   //y가 -6이고 x가 -3, 3 사이인 스폰포인트값

        GameObject balloon = Instantiate(balloonPrefab, spawnPos, Quaternion.identity);
        balloon.AddComponent<BalloonMover>().moveSpeed = moveSpeed;
        Destroy(balloon, 6f);       //6초 뒤 파괴
    }
}

public class BalloonMover : MonoBehaviour
{
    public float moveSpeed = 2f;            //풍선 상승 속도
    public float swaying = 0.3f;            //좌우로 흔들리는 폭
    public float swaySpeed = 2f;            //좌우로 흔들리는 속도

    private Vector3 startPos;               //풍선이 생성될 당시의 시작 위치

    private void Start()
    {
        startPos = transform.position;      //풍선 시작 위치 기억
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);   //풍선 위로 상승
        float sway = Mathf.Sin(Time.time * swaySpeed) * swaying;        //사인을 이용해 좌우로 흔들리는 값 계산
        transform.position = new Vector3(startPos.x + sway, transform.position.y, transform.position.z);    //흔들림을 x축에 더함
    }
}
