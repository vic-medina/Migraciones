using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private EntityPool enemyPool;

    [Header("Configuracion")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float yRandomRange = 1f;
    [SerializeField] private float timer;

    public void Restart()
    {

    }

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y += Random.Range(-yRandomRange, yRandomRange);
        enemyPool.GetFromPool(spawnPos);
    }
}
