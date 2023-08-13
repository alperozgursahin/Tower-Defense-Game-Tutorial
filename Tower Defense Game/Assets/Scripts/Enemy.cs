using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
    private int wavepointIndex = 0;
    public int health = 100;
    public int gainMoney = 50;
    public GameObject deathEffectPrefab;
    public void TakeDamage(int damageAmount)
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
        GameObject effect = (GameObject) Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += gainMoney;
    }

    void Start()
    {
        target = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
       Vector3 dir = target.position - transform.position;
       transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length-1)
        {
            EndPath();

        }
        else
        {
            wavepointIndex++;
            target = Waypoints.waypoints[wavepointIndex];
        }
        
    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.Lives--;

    }
}
