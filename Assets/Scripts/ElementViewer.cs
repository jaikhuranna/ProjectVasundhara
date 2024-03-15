using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementViewer : MonoBehaviour
{
    public TMP_Text label;

    public GameObject Disp;

    private Ray[,] checks;
    // Start is called before the first frame update
    void Start()
    {
        checks = new Ray[5,5];
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(r, out RaycastHit hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.TryGetComponent<ElementTemplate>(out ElementTemplate element))
            {
                Debug.Log("Hit an Element "+ element.Elementname);
                Disp.SetActive(true);
                Disp.transform.position = element.transform.position + new Vector3(0,0.1f,0);
                label.text = element.Elementname;
            }
            else
            {
                Disp.SetActive(false);
            }
        }
        else
        {
            Disp.SetActive(false);
        }
        
    }
}
