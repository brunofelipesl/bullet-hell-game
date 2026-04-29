using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public int maxBombs = 3;
    private int currentBombs;

    public float invulnerabilityTime = 2f;

    private InputHandler input;
    private PlayerHealth health;
    private bool bombUsedThisPress;

    public BombCutIn bombCutIn;

    void Start()
    {
        currentBombs = maxBombs;
        input = GetComponent<InputHandler>();
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (input.BombPressed && !bombUsedThisPress)
        {
            UseBomb();
            bombUsedThisPress = true;
        }

        if (!input.BombPressed)
        {
            bombUsedThisPress = false;
        }
    }

    bool inputEnabled()
    {
        return true;
    }

    bool inputBombPressed()
    {
        return inputActionsBomb();
    }

    bool inputActionsBomb()
    {
        return false;
    }

    public void UseBomb()
    {
        if (currentBombs <= 0) return;

        currentBombs--;

        Debug.Log("Bomba usada! Restantes: " + currentBombs);

        bombCutIn.Play();

        ClearBullets();

        StartCoroutine(Invulnerability());
    }

    void ClearBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    System.Collections.IEnumerator Invulnerability()
    {
        health.SetInvulnerable(true);

        yield return new WaitForSeconds(invulnerabilityTime);

        health.SetInvulnerable(false);
    }
}
