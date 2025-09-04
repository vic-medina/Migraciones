using UnityEngine;

public class BackgroundTrigger : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] BackGroundSwitch bgsw;

    [Header("Indice")]
    [SerializeField] private int fondoDestinoIndex; // Elige el fondo en el inspector
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(bgsw.FadeFondos(fondoDestinoIndex));
        }
    }
}
