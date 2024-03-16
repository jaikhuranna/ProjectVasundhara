using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitialiser : MonoBehaviour
{
    // Start is called before the first frame update
    private OffsetCustomizer camraOffset;
    void Start()
    {
        camraOffset = FindObjectOfType<OffsetCustomizer>();
        transform.position = camraOffset.transform.position + new Vector3(0,  0 ,0);

    }
}
