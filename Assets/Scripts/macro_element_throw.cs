using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macro_element_throw : MonoBehaviour
{
    public GameObject Effect;

 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "TriggerGround")
        {
            Debug.Log("Hit The Ground Trigger");
            Instantiate(Effect);
        }
    }
}
