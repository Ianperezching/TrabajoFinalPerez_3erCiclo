using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public RectTransform[] uiElements;
    public float moveDuration = 1f;
    public Vector2[] targetPositions;
    public Vector2[] targetScales;
    public GameObject SetingsMenu;
    public GameObject CreditsMenu;

    void Start()
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            uiElements[i].DOAnchorPos(targetPositions[i], moveDuration);
            uiElements[i].DOScale(targetScales[i], moveDuration);
        }
    }
    public void Setings(bool Activar)
    {
        SetingsMenu.SetActive(Activar);
    }
    public void Credits(bool Activar)
    {
        CreditsMenu.SetActive(Activar);
    }
    public void Play()
    {
        SceneManager.LoadScene("Juego");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
