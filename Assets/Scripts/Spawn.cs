using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject _prefab;

    public void Spawner()
    {
        if (_prefab == null)
        {
            return;
        }
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
