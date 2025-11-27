using UnityEngine;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup mainMenu;
    [SerializeField] private CanvasGroup speciesPanel;
    [SerializeField] private CanvasGroup infoPanel;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private GameSelector gameSelector;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void ShowMainMenu()
    {
        SwitchCanvas(speciesPanel, mainMenu);
    }

    public void ShowSpeciesMenu()
    {
        SwitchCanvas(mainMenu, speciesPanel);
    }

    public void ShowSpeciesMenufromInfo()
    {
        SwitchCanvas(infoPanel, speciesPanel);
        gameSelector.selectSpecieButton.interactable = false;
    }

    public void ShowSpeciesInfo()
    {
        gameSelector.ShowGameInfo();
        SwitchCanvas(speciesPanel, infoPanel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchCanvas(CanvasGroup from, CanvasGroup to)
    {
        from.DOFade(0, fadeDuration).OnComplete(() => from.interactable = from.blocksRaycasts = false);
        to.DOFade(1, fadeDuration);
        to.interactable = to.blocksRaycasts = true;
    }
}