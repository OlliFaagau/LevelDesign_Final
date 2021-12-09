using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
    public Transform[] points;
    public NavMeshAgent nav;

    private int destPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance <= 0)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
