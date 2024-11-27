using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayFX()
    {
        _particleSystem.Play();
    }

    public void StopFX()
    {
        _particleSystem.Stop();
    }

    public void Start()
    {
        _particleSystem.Stop();
    }
}
