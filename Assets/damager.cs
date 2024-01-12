using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damager : MonoBehaviour
{
    public float damage = 10f;
    public float cooldown =  .2f;
    private float ctime;
    bool canAttack;
    // Start is called before the first frame update
    void Start() {
        canAttack = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAttack) {
            if (ctime >= cooldown)
            {
                ctime = 0;
                canAttack = true;
            }
            else {
                ctime += Time.deltaTime;
            }
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")&& canAttack) { 
            if(collision.gameObject.GetComponent<playerhealth>() != null)
            {
                collision.gameObject.GetComponent<playerhealth>().takedamage(damage);
                canAttack = false;

            }
        }
    }
}
