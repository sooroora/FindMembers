using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public GameObject successUI;
    public float spawnTime = 2f;
    public float moveSpeed = 2f;
    
    private void Start()
    {
        InvokeRepeating("SpawnBalloon", 0f, spawnTime);
    }

    private void SpawnBalloon()
    {
        if (GameManager.Instance.currentLevel == 3) { }
        else if (!successUI.activeSelf) return;

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
    public float swaying = 0.3f;
    public float swaySpeed = 2f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        float sway = Mathf.Sin(Time.time * swaySpeed) * swaying;
        transform.position = new Vector3(startPos.x + sway, transform.position.y, transform.position.z);
    }
}
