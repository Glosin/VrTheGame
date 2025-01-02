using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BookHit : MonoBehaviour
{
    public AudioClip[] audioClip;

    private void OnCollisionEnter(Collision other)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip[Random.Range(0, audioClip.Length)]);
    }
}
