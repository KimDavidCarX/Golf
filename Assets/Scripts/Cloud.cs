using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlSystem;

    public void PlayFX()
    {
        _particlSystem.Play();
    }

    public void StopFX()
    {
        _particlSystem.Stop();
    }

    public void Start()
    {
        _particlSystem.Stop();
    }
}
