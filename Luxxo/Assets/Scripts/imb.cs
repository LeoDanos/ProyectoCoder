using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imb : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    bool firstPlay = false;
    
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Player")) && !firstPlay)
        {
            audioSource.PlayOneShot(audioClip);
            firstPlay = true;
        }
    }
}
