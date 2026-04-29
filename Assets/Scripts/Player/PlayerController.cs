using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private InputHandler input;

    void Awake()
    {
        input = GetComponent<InputHandler>();
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
            Debug.Log("Colidiu com: " + other.name);
            Destroy(other.gameObject);
        }
    }
}
