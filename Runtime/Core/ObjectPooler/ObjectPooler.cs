using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fate/Object Pooling/Object Pooler")]
public class ObjectPooler : ScriptableObject
{
    private Dictionary<string, ObjectPool> table;

    public void Initialize()
    {
        table = new();
        ObjectPool[] pools = Resources.FindObjectsOfTypeAll<ObjectPool>();
        for (int i = 0; i < pools.Length; i++)
        {
            ObjectPool pool = pools[i];
            table.Add(pool.Tag, pool);
        }
    }

    public void Get(string tag)
    {
        if (table.ContainsKey(tag))
            table[tag].Get();
        else
        {
            Debug.LogError(tag + " pool does not exist", this);
        }
    }

    public void ClearPools()
    {
        foreach (ObjectPool pool in table.Values)
        {
            pool.ClearPool();
        }
    }
}
