using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ElementViewer : MonoBehaviour
{
    public TMP_Text label;

    public GameObject Disp;
    public List<ElementTemplate> seen;
    public ElementTemplate SeeingObject;
    public float scale;

    // private Ray[,] checks;
    // Start is called before the first frame update
    void Start()
    {
        // checks = new Ray[5,5];
        seen = new List<ElementTemplate>();
        Disp.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ray r = new Ray(transform.position, transform.forward);
        // if (Physics.Raycast(r, out RaycastHit hit, Mathf.Infinity))
        // {
        //     Debug.Log(hit.collider.name);
        //     if (hit.collider.TryGetComponent<ElementTemplate>(out ElementTemplate element))
        //     {
        //         Debug.Log("Hit an Element "+ element.Elementname);
        //         Disp.SetActive(true);
        //         Disp.transform.position = element.transform.position + new Vector3(0,0.1f,0);
        //         label.text = element.Elementname;
        //     }
        //     else
        //     {
        //         Disp.SetActive(false);
        //     }
        // }
        // else
        // {
        //     Disp.SetActive(false);
        // }

        if (Disp.activeInHierarchy && SeeingObject != null)
        {
            //Disp.transform.position = SeeingObject.transform.position + new Vector3(0,0.1f,0);
            // Disp.GetComponent<RectTransform>().localScale = ;
            // Disp.GetComponent<RectTransform>().transform.LookAt(transform.position);
            // Disp.transform.parent.position = SeeingObject.transform.position + new Vector3(0,0.1f,0);
            // Disp.transform.parent.transform.rotation = Quaternion.LookRotation(transform.position);
            
            
            // Disp.transform.rotation = quaternion.LookRotation(transform.position,Vector3.up);
            // Vector2 newsize = Vector2.one * (Vector3.Distance(Disp.transform.position, transform.position) / scale);
            // Disp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,newsize.x);
            // Disp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,newsize.y);
            // label.text = SeeingObject.Elementname;
            
            
            
            if (SeeingObject != null)
            {
                // // Calculate the direction from UI to the player's camera
                // Vector3 lookDirection = Camera.main.transform.position - Disp.transform.position;
                //
                // // Ensure the UI element faces the player's camera
                // Disp.transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

                Vector3 lookDirection = Disp.transform.position - transform.position;
                Disp.transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
                
                // Adjust size based on distance from the camera
                Vector2 newsize = Vector2.one * (Vector3.Distance(Disp.transform.position, Camera.main.transform.position) / scale);
                // Disp.GetComponent<RectTransform>().eulerAngles = transform.position;
                // Disp.GetComponent<RectTransform>().LookAt(transform.position);
                Disp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newsize.x);
                Disp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newsize.y);

                label.text = SeeingObject.Elementname;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ElementTemplate>(out ElementTemplate element))
        {
            seen.Add(element);

            if (seen.Count > 0)
            {
                var ele = seen[0];
                
                foreach (var seenelement in seen)
                {
                    if (seenelement != null)
                    {
                        if (Vector3.Distance(transform.position, seenelement.transform.position) <
                            Vector3.Distance(ele.transform.position, transform.position))
                        {
                            ele = seenelement;
                        }  
                    }
                    
                }
                
                Disp.SetActive(true);
                Disp.transform.position = ele.transform.position + new Vector3(0,0.1f,0);
                label.text = ele.Elementname;
                SeeingObject = ele;
            }
            else
            {
                Disp.SetActive(false);
                SeeingObject = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.TryGetComponent<ElementTemplate>(out ElementTemplate element))
            {
                seen.Remove(element);

                if (seen.Count > 0)
                {
                    var ele = seen[0];

                    foreach (var seenelement in seen)
                    {
                        if (Vector3.Distance(transform.position, seenelement.transform.position) <
                            Vector3.Distance(ele.transform.position, transform.position))
                        {
                            ele = seenelement;
                        }
                    }
                
                    Disp.SetActive(true);
                    Disp.transform.position = ele.transform.position + new Vector3(0,0.1f,0);
                    label.text = ele.Elementname;
                    SeeingObject = ele;
                }
                else
                {
                    Disp.SetActive(false);
                    SeeingObject = null;
                }
            }
        }
        
    }
    
}
