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
    [Header("Shield Enemy")]
    public bool hasShield;
    public float startShieldHealth = 100f;
    private float shield;


    [Header("Unity Stuff")]
    public Image healthBar;
    public Image shieldBar;

    private bool isDead = false;
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        if (hasShield)
            shield = startShieldHealth;

    }
    public void TakeDamage(float damageAmount)
    {
        if (hasShield)
        {
            if (damageAmount > shield)
            {
                hasShield = false;
                shieldBar.enabled = false;
                health -= damageAmount - shield;
                healthBar.fillAmount = health / startHealth;
            }
            else
            {
                shield -= damageAmount;
                shieldBar.fillAmount = shield / startShieldHealth;
            }
        }
        else
        {
            health -= damageAmount;
            healthBar.fillAmount = health / startHealth;
        }


        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;
        GameObject effect = (GameObject)Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;

    }

    public void Slow(float slowRate)
    {
        speed = startSpeed * (1f - slowRate);
    }




}
