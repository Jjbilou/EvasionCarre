using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem dieParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        dieParticleSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
