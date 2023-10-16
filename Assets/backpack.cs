using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class backpack : MonoBehaviour
{
    public TMP_Text coinText;
    public int coins;
    public void getCoin() {
        coins++;
        coinText.text = coins.ToString() + " coins";
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coins.ToString() + " coins"; 
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
