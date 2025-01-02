using UnityEngine;
using UnityEngine.Events;

public class OnTargetReached : MonoBehaviour
{
    public float treshold = 0.2f;
    public Transform target;
    public UnityEvent onReached;
    public bool wasReached = false;

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < treshold && !wasReached)
        {
            onReached.Invoke();
            wasReached = true;
        }
        else if (distance >= treshold)
            wasReached = false;
    }
}
