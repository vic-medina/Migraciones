using UnityEngine;
using Pabio.Migraciones.Displays;

public class HUD : MonoBehaviour
{
    public Minimap playerMinimap;

    public void Restart()
    {
        playerMinimap.Restart();
        ShowHUD();
    }

    public void NextLocation(int index)
    {
        playerMinimap.NextLocation(index);
    }

    public void HideHUD()
    {
        gameObject.SetActive(false);
    }

    public void ShowHUD()
    {
        gameObject.SetActive(true);
    }
}