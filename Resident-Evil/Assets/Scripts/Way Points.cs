using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPoints : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();

    public int distance = 2;

    private NavMeshAgent agent;

    public int curWayPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
    }

    private void Walking()
    {
        if (points.Count == 0)
        {
            return;
        }

        float distanceToWP = Vector3.Distance(points[curWayPoint].position, transform.position);

        if (distanceToWP <= distance)
        {
            curWayPoint = (curWayPoint + 1) % points.Count;
        }

        agent.SetDestination(points[curWayPoint].position);
    }
}
