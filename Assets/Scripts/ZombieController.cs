using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ZombieController : MonoBehaviour
{
    public float attackDistance = 1.5f;
    public float health = 7f;
    private Camera _mainCamera;
    private NavMeshAgent _navMeshAgent;
    
    public virtual void Start()
    {
        _mainCamera = Camera.main;
        _navMeshAgent = transform.GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (health > 0)
        {
            Walk();
            float distance = Vector3.Distance(transform.position, _mainCamera.transform.position);
            if (distance < attackDistance)
                Attack();
        }
        else
            Kill();
    }

    public virtual void Walk()
    {
        _navMeshAgent.SetDestination(_mainCamera.transform.position);
    }

    public virtual void Attack() {}
    public virtual void StopAttack() {}

    public virtual void Kill()
    {
        _navMeshAgent.isStopped = true;
        _navMeshAgent.ResetPath();
        _navMeshAgent.speed = 0f;
        Destroy(gameObject, 3f);
    }
}
