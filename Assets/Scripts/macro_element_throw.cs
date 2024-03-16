using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macro_element_throw : MonoBehaviour
{
    public GameObject UnActiveMesh;
    public ParticleSystem ThrowParticle;
    

    private void Start()
    {
        Debug.Log(FindObjectOfType<ManagedEnvs>().test);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))

        {
            switch (GetComponent<ElementTemplate>().Elementname)
            {
                case "Ocean":
                    FindObjectOfType<ManagedEnvs>().wateractive();
                    break;
                case "Soil":
                    FindObjectOfType<ManagedEnvs>().soilactive();
                    break;
                case "Tree":
                    FindObjectOfType<ManagedEnvs>().treeactive();
                    break;
                case "Stone":
                    FindObjectOfType<ManagedEnvs>().stoneactive();
                    break;
            }
            
            ThrowParticle.Play();
            Destroy(gameObject,1f);
        }

        if (other.CompareTag("Sky"))
        {
            Debug.Log("Loading Sun");
            FindObjectOfType<ManagedEnvs>().toSUN();
        }
    }
}
