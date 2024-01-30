using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopManager : MonoBehaviour
{
    public GameObject shop;
    bool shopActive = false;

    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(shopActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            shopActive = !shopActive;
            shop.SetActive(!shopActive);
            if(shopActive)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState= CursorLockMode.None;
            }
        }
    
    }
}
