using UnityEngine;
using UnityEngine.Pool;

public class EntityPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxPoolSize = 20;
    [SerializeField] private bool collectionChecks = true;

    public IObjectPool<GameObject> e_pool { get; private set; }

    private void Awake()
    {
        e_pool = new ObjectPool<GameObject>(CreateItem, OnGet, OnRelease, OnDestroyItem, collectionChecks, 10, maxPoolSize);
    }

    private GameObject CreateItem()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        return obj;
    }

    private void OnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyItem(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject GetFromPool(Vector3 position)
    {
        GameObject obj = e_pool.Get();
        obj.transform.position = position;
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        e_pool.Release(obj);
    }
}