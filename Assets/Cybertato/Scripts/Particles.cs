using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public Collider handCollider;
    public ParticleSystem LRParticles;

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        LRParticles.Play();
    }
}
