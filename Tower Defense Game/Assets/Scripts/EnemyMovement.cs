using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;
    private float turnSpeed = 0.05f;
    Quaternion rotGoal;
    Vector3 direction;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;

        // Rotation
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);




    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
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
        WaveSpawner.EnemiesAlive--;
        if (PlayerStats.Lives > 0)
            PlayerStats.Lives--;

    }

}
