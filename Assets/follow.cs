using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Animate 
public class follow : MonoBehaviour
{
    public Transform player;
    public float movespeed = 30.0f;
    public float stoppingDistance = 3.0f;
    public bool isFollowing = true;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        anim.SetFloat("Speed", movespeed);
        if (player == null)
        {
            return;
        }
        if (player.position.y < 8)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > stoppingDistance) ;
            {
                Vector3 moveDirection = (player.position - transform.position).normalized;
                transform.Translate(moveDirection * movespeed * Time.deltaTime);
            }
        }
        
    }
}
    