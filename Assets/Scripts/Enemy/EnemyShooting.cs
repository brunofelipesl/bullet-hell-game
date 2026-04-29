using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireRate = 0.1f;
    public float rotationSpeed = 100f; // velocidade da espiral

    private float timer;
    private float angle;

    void Update()
    {
        timer += Time.deltaTime;
        angle += rotationSpeed * Time.deltaTime;

        if (timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        SpawnBullet(angle);
        SpawnBullet(angle + 180f);
    }

    void SpawnBullet(float ang)
    {
        float rad = ang * Mathf.Deg2Rad;

        Vector3 dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        EnemyBullet eb = bullet.GetComponent<EnemyBullet>();
        eb.direction = dir;
    }
}
