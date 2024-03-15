using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotGravity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ElementTemplate element))
        {
            element.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ElementTemplate element))
        {
            element.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
