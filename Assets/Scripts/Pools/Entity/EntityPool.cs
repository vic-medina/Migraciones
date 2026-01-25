using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class EntityPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxPoolSize = 20;
    [SerializeField] private bool collectionChecks = true;

    public IObjectPool<GameObject> e_pool { get; private set; }

    [SerializeField] private List<GameObject> activeObjects = new List<GameObject>();

    private void Awake()
    {
        e_pool = new ObjectPool<GameObject>(
            CreateItem,
            OnGet,
            OnRelease,
            OnDestroyItem,
            collectionChecks,
            10,
            maxPoolSize
        );
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
        activeObjects.Add(obj);
    }

    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
        activeObjects.Remove(obj);
    }

    private void OnDestroyItem(GameObject obj)
    {
        activeObjects.Remove(obj);
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

    public void ReturnAll()
    {
        // Copia para evitar modificar la lista mientras iteras
        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            e_pool.Release(activeObjects[i]);
        }
    }
}
