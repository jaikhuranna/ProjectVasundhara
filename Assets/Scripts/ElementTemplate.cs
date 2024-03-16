using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class ElementTemplate : MonoBehaviour
{

    public string Elementname;
    public Rigidbody selfbody;


    private void OnEnable()
    {
        selfbody = GetComponent<Rigidbody>();
    }
    

    public void SetKinematic()
    {
        selfbody.isKinematic = false;
        selfbody.angularDrag = 1;
        selfbody.drag = 2.5f;
    }
}
