using UnityEngine;

public class BackgroundTrigger : MonoBehaviour
{
    [Header("Referencias")] // Referencia al script de BackGroundSwitch en GameManager
    [SerializeField] BackGroundSwitch bgsw;
    [SerializeField] private CanvasGroup panelZone;

    [Header("Indice")] // Indice del fondo al que se quiere cambiar
    [SerializeField] private int fondoDestinoIndex;
    [SerializeField] private string nombreZona;

    [Header("NewDotPosition")]
    [SerializeField] private Vector2 newDotPosition;
    [SerializeField] private int moveTime;

    private void OnTriggerEnter2D(Collider2D other) // Detecta colisión con el jugador para hacer el cambio de fondo
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(bgsw.FadeFondos(fondoDestinoIndex,nombreZona)); // Inicia la coroutine de fade en el script de BackGroundSwitch
            bgsw.FadeNamePanel(panelZone); // Inicia la coroutine de fade del nombre de la zona
            bgsw.UpdatePlayerDot(newDotPosition,moveTime);
        }
    }
}