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
    public float attackDelay = 3;
    private float ctime;

    // Start is called before the first frame update
    void Start()
    {
     //   anim = GetComponent<Animator>();
        agent= GetComponent<NavMeshAgent>();
        agent.speed= movespeed;
        agent.stoppingDistance= stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (anim) 
        {
            anim.SetFloat("speed", agent.velocity.magnitude);
        }

        if (player == null)
        {
            agent.isStopped = true ;
        }
        else
        {
            agent.isStopped = false;
            if (player.position.y < 2.3f) 
            {
                transform.LookAt(player.position);
            }
            
           // transform.LookAt(player);
            agent.SetDestination(player.position);
            if(Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {

                if (ctime > attackDelay)
                {
                    anim.SetTrigger("attack");
                    ctime = 0;
                }
                else {
                    ctime += Time.deltaTime;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
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
    