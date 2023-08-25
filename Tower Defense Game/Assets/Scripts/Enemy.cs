using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100f;
    private float health;

    public int worth = 50;
    public GameObject deathEffectPrefab;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {  
        if (!isDead)
        {
            PlayerStats.Money += worth;
            GameObject effect = (GameObject)Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
            isDead = true;
        }
        
    }

    public void Slow(float slowRate)
    {
        speed = startSpeed * (1f - slowRate);
    }




}
