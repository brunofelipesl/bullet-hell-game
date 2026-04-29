using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRate = 1.5f;

    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float spawnY = 6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
