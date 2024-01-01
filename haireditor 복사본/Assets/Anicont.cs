using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anicont : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            anim.SetTrigger("hair1");
            Debug.Log("hair1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            anim.SetTrigger("hair2");
            Debug.Log("hair2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            anim.SetTrigger("hair3");
            Debug.Log("hair3");
        }
    }
}
