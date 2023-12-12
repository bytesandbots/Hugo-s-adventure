using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    bool canspawn;
    int amountofenemy = 1;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canspawn) {
            for (int i = 0; i < amountofenemy; i++)
            {
                Instantiate(enemy,transform.position,Quaternion.identity);
            } 

            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 
            canspawn = true;
        }
    }
}
