using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject initialPanel;
    [SerializeField] private GameObject pasuePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject coverScreen;

    public float waitTimeToFinal;
    public float waitTimeToRestart;

    public void Restart()
    {
        coverScreen.SetActive(true);
        StartCoroutine(OffScreen());

        initialPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        pasuePanel.SetActive(false);
        winPanel.SetActive(false);
        finalPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void Pause()
    {
        pasuePanel.SetActive(true);
    }

    public void Continue()
    {
        pasuePanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Win()
    {
        winPanel.SetActive(true);
        StartCoroutine(GoToFinalPanel());
    }

    public IEnumerator GoToFinalPanel()
    {
        yield return new WaitForSeconds(waitTimeToFinal);
        finalPanel.SetActive(true);
    }

    public void GoToCredits()
    {
        creditsPanel.SetActive(true);
    }

    private IEnumerator OffScreen()
    {
        yield return new WaitForSeconds(waitTimeToRestart);
        coverScreen.SetActive(false);
    }
}
