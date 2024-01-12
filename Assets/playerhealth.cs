using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerhealth : MonoBehaviour
{
    public float totalhealth = 100;
    private float currenthealth;
    public Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = totalhealth;
        healthbar.fillAmount = currenthealth / totalhealth;

    }

    public void takedamage(float damage)
    {
        currenthealth -= damage;
        healthbar.fillAmount = currenthealth / totalhealth;
        if (currenthealth <= 0) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
