using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macro_element_throw : MonoBehaviour
{
    public GameObject UnActiveMesh;
    public ParticleSystem ThrowParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            UnActiveMesh.SetActive(true);
            ThrowParticle.Play();
            Destroy(gameObject,1f);
        }

        if (other.gameObject.CompareTag("Sky"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0,2500f,0);
            StartCoroutine(sunBurst());
            //Destroy(gameObject,3f);
        }
    }

    IEnumerator sunBurst()
    {
        
        yield return new WaitForSeconds(3f);
        ThrowParticle.Play();
    }
}
