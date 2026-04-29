using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BombCutIn : MonoBehaviour
{
    public Image image;
    public float fadeDuration = 0.2f;
    public float displayTime = 0.5f;

    private void Awake()
    {
        image.color = new Color(0.2f, 0, 0.4f, 0);
    }

    public void Play()
    {
        StartCoroutine(PlayCutIn());
    }

    IEnumerator PlayCutIn()
    {
        // fade in
        yield return Fade(0f, 0.6f);

        // segura na tela
        yield return new WaitForSeconds(displayTime);

        // fade out
        yield return Fade(0.6f, 0f);
    }

    IEnumerator Fade(float from, float to)
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, t / fadeDuration);

            image.color = new Color(0, 0, 0, alpha);

            yield return null;
        }
    }
}
