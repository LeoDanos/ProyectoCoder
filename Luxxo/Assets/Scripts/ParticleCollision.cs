using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public GameObject particles;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy")) || (collision.gameObject.CompareTag("Obstacle")) || (collision.gameObject.CompareTag("Wall")))
        {
            Instantiate(particles, collision.contacts[0].point, transform.rotation);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
