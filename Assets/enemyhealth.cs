using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyhealth : MonoBehaviour
{
    public float totalhealth = 100;
    private float currenthealth;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = totalhealth;

    }

    public void takedamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            Instantiate(coin,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
