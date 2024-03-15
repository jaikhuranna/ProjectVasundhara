using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    public GameObject mainElement1;
    public GameObject mainElement2;
    
    public Collider exitTrigger;
    
    private Vector3 mE1Pos;
    private Vector3 mE2Pos;
    // Start is called before the first frame update
    void Start()
    {
        mE1Pos = mainElement1.transform.position;
        mE2Pos = mainElement2.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("1stPso: " + mE1Pos);
        Debug.Log("2nd pos: " + mE2Pos);
        Instantiate(mainElement1, mE1Pos, transform.rotation);
        Instantiate(mainElement2, mE2Pos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
