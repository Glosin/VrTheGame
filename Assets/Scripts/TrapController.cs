using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class TrapController : MonoBehaviour
{
    public enum Options {None, FlyingBooks, Music, Lights}
    public Options type;
    public AudioSource audioSource;

    #region FlyingBooks

        public GameObject[] books;
        public GameObject direction;
        public enum Axis { None, XAxis, YAxis, ZAxis };
        public Axis selectedAxis;
        
        private float _minSpeed = 1f; // Minimum movement speed
        private float _maxSpeed = 5f;
        private bool _moveBooks = false;
        private bool _activatedBooks = false;
        private Vector3 _targetPosition;
        private Dictionary<GameObject, float> _objectSpeeds;

    #endregion
    
    #region Music
    
        public AudioClip[] audioClips;
        private bool _activatedMusic = false;
    
    #endregion
    
    #region Lights
    
        public Lamp lightLamp;
        private bool _activeLight;
    
    #endregion
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            #region FlyingBooks

                if (type == Options.FlyingBooks && !_activatedBooks)
                {
                    _activatedBooks = _moveBooks = true;
                    audioSource.Play();
                    StartCoroutine(StopMovingBooks());
                }

            #endregion
            
            #region Music
            if (type == Options.Music && !_activatedMusic)
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                _activatedMusic = true;
                StartCoroutine(AllowNextMusic());
            }
            #endregion

            #region Lights

            if (type == Options.Lights && !_activeLight)
            {
                _activeLight = true;
                StartCoroutine(LightsSwitch());
            }

            #endregion
        }
    }
    
    #region FlyingBooks
    
        void Start()
        {
            _objectSpeeds = new Dictionary<GameObject, float>();

            foreach (GameObject obj in books)
            {
                float randomSpeed = Random.Range(_minSpeed, _maxSpeed);
                _objectSpeeds.Add(obj, randomSpeed);
            }
        }

        void Update()
        {
            if (type == Options.FlyingBooks)
            {
                if (_moveBooks && selectedAxis != Axis.None)
                {
                    foreach (GameObject obj in books)
                    {
                        if (obj == null) continue;

                        float speed = _objectSpeeds[obj];
                        Vector3 currentPosition = obj.transform.position;

                        float random1 = Random.Range(-0.5f, 0.5f); // Adjust range for randomness
                        float random2 = Random.Range(-0.5f, 0.5f);

                        _targetPosition = selectedAxis switch
                        {
                            Axis.XAxis => new Vector3(direction.transform.position.x, currentPosition.y + random1,
                                currentPosition.z + random2),
                            Axis.YAxis => new Vector3(currentPosition.x + random1, direction.transform.position.y,
                                currentPosition.z + random2),
                            _ => new Vector3(currentPosition.x + random1, currentPosition.y + random2,
                                direction.transform.position.z)
                        };

                        obj.transform.position = Vector3.MoveTowards(currentPosition, _targetPosition, speed * Time.deltaTime);
                        StartCoroutine(DestroyBooksOverTime());
                    }
                }
            }
        }
        IEnumerator StopMovingBooks()
        {
            yield return new WaitForSeconds(0.5f);
            _moveBooks = false;
        }
        
        IEnumerator DestroyBooksOverTime()
        {
            yield return new WaitForSeconds(15f);
            foreach (GameObject obj in books)
                Destroy(obj);
        }
        
    #endregion
    
    #region Music
        IEnumerator AllowNextMusic()
        {
            yield return new WaitForSeconds(15f);
            _activatedMusic = false;
        }
    #endregion
    
    #region Lights

    IEnumerator LightsSwitch()
    {
        int random = Random.Range(0, 10);
        while (random > 0)
        {
            lightLamp.Toggle();
            --random;
            yield return new WaitForSeconds(Random.Range(0f, 4f));
        }
        lightLamp.EnableLight();
        if (Random.value > 0.9f)
            lightLamp.DestroyLight();
    }
    
    #endregion
        
}
