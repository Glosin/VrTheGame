using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BookHit : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    private void OnCollisionEnter(Collision other)
    {
        audioSource.PlayOneShot(audioClip[Random.Range(0, audioClip.Length)]);
    }
}
