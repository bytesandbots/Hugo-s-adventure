using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skellyanimation : MonoBehaviour
{
    public Animator anim;
  
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();
    }

}
