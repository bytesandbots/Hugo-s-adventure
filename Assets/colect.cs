using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class colect : MonoBehaviour
{
    public int coinCounter = 0;
    public TMP_Text coinText ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin") {
            coinCounter++;
            GetComponentInParent<backpack>().getCoin();
            other.gameObject.SetActive(false);
           
        }
        if (other.gameObject.tag == "coin")
        {
            coinCounter++;

        }
    }


}
