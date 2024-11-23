// /Scripts/FloorManager.cs
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    public TurnManager turnManager;
    public Image fadeImage; 
    public int currentFloor = 1;
    public EnemyStats[] enemyStatsTemplates;

    public float fadeDuration = 1.0f; 

    private void Start()
    {
        SetupFloor();
    }

    public void AdvanceToNextFloor()
    {
        currentFloor++;
        StartCoroutine(TransitionToNextFloor());
    }

    private IEnumerator TransitionToNextFloor()
    {
        yield return StartCoroutine(FadeOut());
        SetupFloor();
        yield return StartCoroutine(FadeIn());
    }

    private void SetupFloor()
    {
        for (int i = 0; i < turnManager.enemyCombatants.Length; i++)
        {
            EnemyCombatant enemy = turnManager.enemyCombatants[i];
            int templateIndex = Random.Range(0, enemyStatsTemplates.Length);
            enemy.stats = Instantiate(enemyStatsTemplates[templateIndex]);
            enemy.stats.ScaleStats(currentFloor); 
            enemy.stats.currentHealth = enemy.stats.health;
            enemy.UpdateHealthBar();
        }

        Debug.Log($"Piso {currentFloor} configurado con enemigos más fuertes.");
    }

    private IEnumerator FadeOut()
    {
        Color color = fadeImage.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 1); 
    }

    private IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0); 
    }
}

