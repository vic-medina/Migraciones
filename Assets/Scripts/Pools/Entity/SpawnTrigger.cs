using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private SpawnerManager spawnerManager;
    public List<int> spawnersToActivate = new List<int>();
    public List<int> spawnersToDeactivate = new List<int>();

    private void Start()
    {
        spawnerManager = FindAnyObjectByType<SpawnerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (int index in spawnersToActivate)
                spawnerManager.ActivateSpawner(index);

            foreach (int index in spawnersToDeactivate)
                spawnerManager.DeactivateSpawner(index);
        }
    }
}
