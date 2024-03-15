using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : MonoBehaviour
{
    public GameObject Element;

    private Vector3 elementPos;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collder exited");
        if (other.TryGetComponent(out ElementTemplate element))
        {
            Instantiate(Element, elementPos, transform.rotation);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        elementPos = Element.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
