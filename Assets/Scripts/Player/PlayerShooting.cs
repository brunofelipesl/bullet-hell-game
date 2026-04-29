using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private float fireTimer;
    private InputHandler input;

    void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (input.ShootPressed && fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
