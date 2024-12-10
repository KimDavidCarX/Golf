using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject _prefabs;

    public void Spawner()
    {
        if (_prefabs == null)
        {
            return;
        }
        Instantiate(_prefabs, transform.position, Quaternion.identity);
    }
}
