using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private SpawnerManager spawnerManager;
    public int spawnerIndex;
    private void Start()
    {
        spawnerManager = FindAnyObjectByType<SpawnerManager>();
    }           
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spawnerManager.ActivateSpawner(spawnerIndex);
        }    
    }
}
