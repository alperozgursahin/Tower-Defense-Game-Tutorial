using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
    private int wavepointIndex = 0;
   
   
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
            Destroy(gameObject);
        }else
        {
            wavepointIndex++;
            target = Waypoints.waypoints[wavepointIndex];
        }
        
    }
}
