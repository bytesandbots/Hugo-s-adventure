using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class follow : MonoBehaviour
{
    public Transform player;
    public float movespeed = 30.0f;
    public float stoppingDistance = 3.0f;
    public bool isFollowing = true;
    public Animator anim;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        agent.speed= movespeed;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (anim) {
            anim.SetFloat("Speed", movespeed);
        }

        if (player == null)
        {
            agent.isStopped = true ;
        }
        else {
            agent.isStopped = false;
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            isFollowing = true;
            player = other.gameObject.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = false ;
            player = null;
        }
    }
}
    