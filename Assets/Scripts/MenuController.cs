using UnityEngine;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup mainMenu;
    [SerializeField] private CanvasGroup creditsMenu;
    [SerializeField] private CanvasGroup speciesMenu;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private GameSelector gameSelector;

    private void Start()
    {
        ShowOnly(mainMenu);
    }

    public void ShowCredits()
    {
        SwitchCanvas(mainMenu, creditsMenu);
    }

    public void ShowMainMenu()
    {
        if (creditsMenu.alpha == 1)
        {
            SwitchCanvas(creditsMenu, mainMenu);
        }
        else if (speciesMenu.alpha == 1)
        {
            SwitchCanvas(speciesMenu, mainMenu);
            gameSelector.playButton.interactable = false;
        } 
    }

    public void ShowSpeciesMenu()
    {
        SwitchCanvas(mainMenu, speciesMenu);
    }

    private void SwitchCanvas(CanvasGroup from, CanvasGroup to)
    {
        from.DOFade(0, fadeDuration).OnComplete(() => from.interactable = from.blocksRaycasts = false);
        to.DOFade(1, fadeDuration);
        to.interactable = to.blocksRaycasts = true;
    }

    private void ShowOnly(CanvasGroup target)
    {
        mainMenu.alpha = 0;
        creditsMenu.alpha = 0;
        speciesMenu.alpha = 0;

        mainMenu.interactable = mainMenu.blocksRaycasts = false;
        creditsMenu.interactable = creditsMenu.blocksRaycasts = false;
        speciesMenu.interactable = speciesMenu.blocksRaycasts = false;

        target.alpha = 1;
        target.interactable = target.blocksRaycasts = true;
    }
}