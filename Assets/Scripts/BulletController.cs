using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZombieController>() != null)
        {
            other.gameObject.GetComponent<ZombieController>().Hit();
        }
    }
}
