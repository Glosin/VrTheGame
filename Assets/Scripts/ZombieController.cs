using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ZombieController : MonoBehaviour
{
    public int level;
    public float attackDistance, health, attackCooldown;
    public Animator animator;
    public AudioSource audioSourceIdle, audioSourceActions;
    public AudioClip[] audioIdle, audioHit;
    private Camera _mainCamera;
    private NavMeshAgent _navMeshAgent;
    private bool _isAttacking, _isWalking;
    private float _lastAttackTime;
    
    public virtual void Start()
    {
        _mainCamera = Camera.main;
        _navMeshAgent = transform.GetComponent<NavMeshAgent>();
        health = 100f * level;
    }

    public void Update()
    {
        if (!(health > 0)) return;
        if (!audioSourceIdle.isPlaying) PlayRandomClip(audioSourceIdle, audioIdle);
        
        if (!_isAttacking)
        {
            if (!_isWalking) Walk();
            _navMeshAgent.SetDestination(_mainCamera.transform.position);
        }

        
        var distance = Vector3.Distance(transform.position, _mainCamera.transform.position);
        if (distance < attackDistance)
        {
            _isAttacking = true;
            if (_isWalking) WalkStop();;
            if (Time.time >= _lastAttackTime + attackCooldown) Attack();
            
        }
        else _isAttacking = false;
    }

    public void Walk()
    {
        _isWalking = true;
        animator.SetBool("ZombieWalk", true);
        _navMeshAgent.isStopped = false;
    }

    public void WalkStop()
    {
        _isWalking = false;
        animator.SetBool("ZombieWalk", false);
        _navMeshAgent.isStopped = true;
        _navMeshAgent.ResetPath();
    }
    public void Attack()
    {
        _lastAttackTime = Time.time;
        animator.SetTrigger("ZombieAttack");
        FindAnyObjectByType<Player>().Hit(level * 5f);
    }

    public void Hit()
    {
        if (!audioSourceActions.isPlaying) PlayRandomClip(audioSourceActions, audioHit);
        
        health -= 100f;
        if (health <= 0)
            Kill();
        else
            animator.SetTrigger("ZombieHit");
    }

    public void PlayRandomClip(AudioSource source, AudioClip[] clips)
    {
        var clip = clips[Random.Range(0, clips.Length)];
        source.clip = clip;
        source.Play();
    }
    public void Kill()
    {
        audioSourceActions.Play();
        _navMeshAgent.isStopped = true;
        _navMeshAgent.ResetPath();
        _navMeshAgent.speed = 0f;
        audioSourceIdle.Stop();
        FindAnyObjectByType<FlashingLights>().GetComponent<FlashingLights>().active = false;
        animator.SetTrigger("ZombieKill");
        FindAnyObjectByType<ScoreController>().AddScore(50);
        Destroy(gameObject, 3f);
    }
}
