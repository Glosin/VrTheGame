using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float healCooldown = 5f; // Time in seconds before healing occurs
    public float maxHealth = 100f; // Maximum health value
    private float _lastHitTime = 0f; // Tracks the last time the player was hit

    private void Update()
    {
        if (Time.time - _lastHitTime >= healCooldown && health < maxHealth) Heal();
    }

    public void Hit(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth); // Ensure health doesn't go below 0
        _lastHitTime = Time.time; // Update the last hit time
        if (health <= 0)
        {
            FindAnyObjectByType<JumpScare>().JumpScareStart();
            
        }
    }

    private void Heal()
    {
        health = maxHealth;
    }
}
