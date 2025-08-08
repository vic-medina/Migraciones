using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float currentXSpawnPosition;
    [SerializeField] private bool collectionChecks = true;
    [SerializeField] private int maxPoolSize = 15;
    public IObjectPool<GameObject> m_pool { get; set; }

    void Start()
    {
        m_pool = new ObjectPool<GameObject>(CreatePlatform, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
    }

    private GameObject CreatePlatform()
    {
        GameObject platform = Instantiate(platformPrefab, transform);
        platform.SetActive(false);
        return platform;
    }

    private void OnTakeFromPool(GameObject platform)
    {
        platform.transform.position = new Vector3(currentXSpawnPosition, 0, 0);
        platform.gameObject.SetActive(true);

    }

    private void OnReturnedToPool(GameObject platform) => platform.gameObject.SetActive(false);

    private void OnDestroyPoolObject(GameObject platform) => Destroy(platform);

    public void SpawnPlatform() => m_pool.Get();

    public void ReleasePlatform(GameObject platform) => m_pool.Release(platform);

}
