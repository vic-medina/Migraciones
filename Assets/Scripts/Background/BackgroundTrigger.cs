using UnityEngine;

public class BackgroundTrigger : MonoBehaviour
{
    [Header("Referencias")] // Referencia al script de BackGroundSwitch en GameManager
    [SerializeField] BackGroundSwitch bgsw;

    [Header("Indice")] // Índice del fondo al que se quiere cambiar
    [SerializeField] private int fondoDestinoIndex;
    private void OnTriggerEnter2D(Collider2D other) // Detecta colisión con el jugador para hacer el cambio de fondo
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(bgsw.FadeFondos(fondoDestinoIndex)); // Inicia la coroutine de fade en el script de BackGroundSwitch
        }
    }
}
