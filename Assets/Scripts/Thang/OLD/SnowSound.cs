using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip snowSound;
    [SerializeField] private bool loopSound = true; // Option to loop the sound


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Or any other tag for your listener
        {
            if (audioSource == null || snowSound == null)
            {
                Debug.LogError("AudioSource or AudioClip not assigned!");
                return;
            }
            audioSource.clip = snowSound;
            audioSource.loop = loopSound;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}