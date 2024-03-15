using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macro_element_throw : MonoBehaviour
{
    public GameObject GroundMesh;
    public ParticleSystem PSforORB;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            GroundMesh.SetActive(true);
            PSforORB.Play();
            Destroy(gameObject,2);
        }
    }
}
