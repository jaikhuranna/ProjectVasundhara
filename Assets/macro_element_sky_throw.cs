using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macro_element_sky_throw : MonoBehaviour
{

    public ParticleSystem burstParticle; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sky"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0,2500f,0);
            StartCoroutine(sunBurst());
            //Destroy(gameObject,3f);
        }
    }

    IEnumerator sunBurst()
    {
  
        yield return new WaitForSeconds(5f);
        burstParticle.Play();
        FindObjectOfType<ManagedEnvs>().toSUN();
    }
}
