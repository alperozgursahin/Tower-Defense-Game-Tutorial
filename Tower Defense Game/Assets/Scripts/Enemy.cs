using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 50;
    public GameObject deathEffectPrefab;

    void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        GameObject effect = (GameObject)Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += worth;
    }

    public void Slow(float slowRate)
    {
        speed = startSpeed * (1f - slowRate);
    }



    
}
