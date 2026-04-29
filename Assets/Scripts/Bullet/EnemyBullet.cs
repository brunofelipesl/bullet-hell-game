using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.down;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
