using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PooledObject : MonoBehaviourWithCachedTransform
{
    public event Action OnRelease = () => { };
    public abstract void OnObjectSpawn();
    public virtual void Release() => OnRelease.Invoke();
}
