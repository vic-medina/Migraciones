using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            spawners[i].SetActive(false);
        }
    }

    public void Restart()
    {
        foreach (var spawn in spawners)
        {
            spawn.SetActive(false);
        }
    }

    public void ActivateSpawner(int index)
    {
        if (index >= 0 && index < spawners.Count)
        {
            spawners[index].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Spawner index out of range: " + index);
        }
    }

    public void DeactivateSpawner(int index)
    {
        if (index >= 0 && index < spawners.Count)
        {
            spawners[index].SetActive(false);
        }
        else
        {
            Debug.LogWarning("Spawner index out of range: " + index);
        }
    }
}
