using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas creditsCanvas;
    [SerializeField] Canvas selectorSpeciesCanvas;

    public void OpenCredits()
    {
        creditsCanvas.gameObject.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsCanvas.gameObject.SetActive(false);
    }
    public void OpenSelector()
    {
        selectorSpeciesCanvas.gameObject.SetActive(true);
    }

    public void CloseSelector()
    {
        selectorSpeciesCanvas.gameObject.SetActive(false);
    }
}
