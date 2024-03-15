using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OffsetCustomizer : MonoBehaviour
{

    private TriggerInputDetector XRInput;
    // Start is called before the first frame update
    void Start()
    {
        XRInput = FindObjectOfType<TriggerInputDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        var Vinput = XRInput.GetLeftJoyStick().y;
        if ( Vinput != 0)
        {
            transform.Translate(new Vector3(0,Vinput/100f,0));
        }
    }
}
