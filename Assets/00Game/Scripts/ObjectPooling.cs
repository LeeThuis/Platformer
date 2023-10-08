using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    Dictionary<GameObject, List<GameObject>> _pools = new Dictionary<GameObject, List<GameObject>>();

    //private Queue<GameObject> availableObjects = new Queue<GameObject>();
    //[SerializeField] private GameObject afterImagePrefab;

    private void Awake()
    {
        //GrowPool();
    }

    public GameObject GetObject(GameObject key)
    {
        List<GameObject> _pool = new List<GameObject>();
        if (!_pools.ContainsKey(key))
        {
            _pools.Add(key, _pool);
        }
        else
        {
            _pool = _pools[key];
        }

        foreach (GameObject g in _pool)
        {
            if (g.gameObject.activeSelf)
                continue;
            return g;
        }

        GameObject g2 = Instantiate(key, this.transform.position, Quaternion.identity);
        _pools[key].Add(g2);
        return g2;
    }

    //private void GrowPool()
    //{
    //    for(int i = 0; i <10;  i++)
    //    {
    //        var instanceToAdd = Instantiate(afterImagePrefab);
    //        instanceToAdd.transform.SetParent(transform);
    //        AddToPool(instanceToAdd);
    //    }
    //}

    //public void AddToPool(GameObject instance)
    //{
    //    instance.SetActive(false);
    //    availableObjects.Enqueue(instance);
    //}

    //public GameObject GetFromPool()
    //{
    //    if(availableObjects.Count == 0)
    //    {
    //        GrowPool();
    //    }

    //    var instance = availableObjects.Dequeue();
    //    instance.SetActive(true);
    //    return instance;
    //}
}
