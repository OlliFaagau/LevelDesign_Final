using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript_2 : MonoBehaviour
{
    public Transform[] points;
    public NavMeshAgent nav;
    public GameObject player;
    private NavMeshAgent navmesh;

    private int destPoint;
    private float distance;
    private float distanceBtwObj;
    //    private bool isRoaming, isChasing;

    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceBtwObj = Vector3.Distance(player.transform.position, transform.position);

        

        if (distanceBtwObj < 10)
        {
            navmesh.destination = player.transform.position;
            transform.LookAt(player.transform.position);
        }
        else
        {
           if (!nav.pathPending && nav.remainingDistance <= 0)
            GoToNextPoint();
        }
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UI_Script.health -= 10;
            UI_Script.hit = true;
            hitSound.Play();
            Debug.Log("Hit");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            UI_Script.health -= 0.5f;
    }
    void OnCollisionExit(Collision collision)
    {
        UI_Script.hit = false;
    }
}
