using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Script : MonoBehaviour
{
    Animator anim;

    public GameObject[] waypoints;
    public GameObject player;
    public int speed;

    private NavMeshAgent navmesh;
    private float distance;
    private float distanceBtwObjs;
    private int waypointIndex;
    private bool isRoaming;
    private bool isChasing;

    public AudioSource hitSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        navmesh = GetComponent<NavMeshAgent>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].transform.position);
        isRoaming = true;
        isChasing = false;
    }


    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position);
        distanceBtwObjs = Vector3.Distance(player.transform.position, transform.position);

        if (distanceBtwObjs < 15)
        {
            isRoaming = false;
            isChasing = true;
            navmesh.destination = player.transform.position;
            transform.LookAt(player.transform.position);

            if (distanceBtwObjs < 4)
            {
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.SetTrigger("Roam");
            }
        }
        else
        {
            navmesh.isStopped = true;
            isChasing = false;
        }

        if ((distance < 1f || isRoaming == false) && isChasing == false)
        {
            IncreaseIndex();
        }

        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].transform.position);

        isRoaming = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UI_Script.health -= 10;
            UI_Script.hit = true;
            hitSound.Play();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            UI_Script.health -= 0.5f;
    }
    void OnCollisionExit(Collision collision)
    {
        UI_Script.hit = false;
    }
}
