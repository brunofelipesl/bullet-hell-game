using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private InputHandler input;
    private PlayerHealth health;

    void Awake()
    {
        input = GetComponent<InputHandler>();
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        Vector2 movement = input.MoveInput;
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            health.TakeHit();
            Destroy(other.gameObject);
        }
    }
}
