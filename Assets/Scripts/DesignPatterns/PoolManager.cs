using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<MonoBehaviour>
{
    public ObjectPool objectPool;

    public ParticleSystem GetEtheralParticleObject(Vector3 position, Quaternion rotation, Transform parent) 
    {
        return objectPool.GetPooledObject(0, position, rotation, parent).GetComponent<ParticleSystem>();
    }

    public void ReturnEtheralParticleToPool(GameObject bullet) 
    {
        objectPool.AddToPool(0, bullet);
    }

    public ParticleSystem GetSparkParticleObject(Vector3 position, Quaternion rotation, Transform parent) 
    {
        return objectPool.GetPooledObject(1, position, rotation, parent).GetComponent<ParticleSystem>();
    }

    public void ReturnSparkParticleToPool(GameObject bullet) 
    {
        objectPool.AddToPool(1, bullet);
    }

    
}
