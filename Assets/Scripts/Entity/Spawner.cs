using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EntityPool foodPool;
    [SerializeField] private EntityPool enemyPool;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float yRandomRange = 1f;
    [SerializeField][Range(0f, 1f)] private float foodChance = 0.5f;

    private float timer;

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

        if (Random.value <= foodChance)
        {
            foodPool.GetFromPool(spawnPos);
        }
        else
        {
            enemyPool.GetFromPool(spawnPos);
        }
    }

    private void SpawnMeta()
    {
        Vector3 spawnPos = transform.position;
    }

    private IEnumerator spawnMeta(float finishTime)
    {
        yield return new WaitForSeconds(finishTime);
        SpawnMeta();
    }
}