using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GeneralAnimator[] menuScreens;
    [SerializeField] private MenuCharacterSpawner menuChSpw;
    [SerializeField] private GameObject blackBackground;

    private void Awake()
    {
        blackBackground.SetActive(true);
        menuChSpw.StopSpawning();
    }
    private void Start()
    {
        StartCoroutine(Restart());
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        blackBackground.SetActive(false);
        foreach (var menuScreen in menuScreens)
        {
            menuScreen.Restart();
        }
        HideAll();
        ShowScreen(0);
        menuChSpw.AllowSpawning();
    }

    private void HideAll()
    {
        foreach (var screen in menuScreens)
        {
            screen.SetStateTo(false);
        }
    }

    private void HideScreen(int screenIndex)
    {
        if (screenIndex < 0 || screenIndex >= menuScreens.Length) return;
        menuScreens[screenIndex].SetStateTo(false);
    }

    private void ShowScreen(int screenIndex)
    {
        if (screenIndex < 0 || screenIndex >= menuScreens.Length) return;
        menuScreens[screenIndex].SetStateTo(true);
    }


    public void ChangeScreenTo(int screenIndex)
    {
        HideAll();
        ShowScreen(screenIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}