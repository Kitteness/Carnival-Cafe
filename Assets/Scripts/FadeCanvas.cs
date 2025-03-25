using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvas : MonoBehaviour
{
    [Tooltip("Fade duration in seconds.")]
    public float fadeDuration = 1.0f;

    private CanvasGroup canvasGroup;
    private Coroutine currentCoroutine;

    private float alpha;

    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        alpha = canvasGroup.alpha;
    }

    public void StartFadeIn()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(FadeIn(fadeDuration));
    }

    public void StartFadeOut()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(FadeOut(fadeDuration));
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;

        while (alpha < 1.0)
        {
            SetAlpha(elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;

        while (alpha > 0)
        {
            SetAlpha(1 - (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void SetAlpha(float value)
    {
        alpha = value;
        canvasGroup.alpha = alpha;
    }
}
