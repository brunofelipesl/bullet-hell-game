using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    public float respawnDelay = 1f;
    public float invulnerabilityTime = 2f;

    private bool isInvulnerable;

    void Start()
    {
        currentLives = maxLives;
    }

    public void TakeHit()
    {
        if (isInvulnerable) return;

        currentLives--;

        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Respawn());
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
        gameObject.SetActive(false);
    }

    public void SetInvulnerable(bool value)
    {
        isInvulnerable = value;
    }

    System.Collections.IEnumerator Respawn()
    {
        GetComponent<PlayerController>().enabled = false;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        transform.position = Vector3.zero;


        sr.enabled = true;
        GetComponent<PlayerController>().enabled = true;

        StartCoroutine(Invulnerability());
    }

    System.Collections.IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(invulnerabilityTime);

        Renderer rend = GetComponent<SpriteRenderer>();

        float elapsed = 0f;

        while (elapsed < invulnerabilityTime)
        {
            rend.enabled = !rend.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        rend.enabled = true;
        isInvulnerable = false;
    }
}
