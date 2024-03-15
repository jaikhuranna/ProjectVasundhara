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
        for (float i = -0.02f; i < 0.02f; i+= 0.01f)
        {
            for (float j = -0.02f; j < 0.02f; j+= 0.01f)
            {
                checks[(int)((i/0.01f)+2), (int)( + (j/0.01f))] = new Ray(transform.position, transform.forward + new Vector3(transform.position.x+i,transform.position.y+j,transform.position.z));
            }
        }

        List<ElementTemplate> Seen = new List<ElementTemplate>();
        for (int i = 0; i<5; i++)
        {
            for (int j = 0; j<5; j++)
            {
                if (Physics.Raycast(checks[i,j], out RaycastHit hit, Mathf.Infinity))
                {
                    Debug.Log(hit.collider.name);
                    if (hit.collider.TryGetComponent<ElementTemplate>(out ElementTemplate element))
                    {
                        Seen.Add(element);
                        
                    }
                }
            }
        }

        if (Seen.Count != 0)
        {
            ElementTemplate show = Seen[0];
            foreach (var ele in Seen)
            {
                if (Vector3.Distance(transform.position, ele.transform.position) <
                    Vector3.Distance(transform.position, show.transform.position))
                {
                    show = ele;
                }
            }
            
            Debug.Log("Hit an Element "+ show.Elementname);
            Disp.SetActive(true);
            Disp.transform.position = show.transform.position + new Vector3(0,0.1f,0);
            label.text = show.Elementname;
            
        }
        else
        {
            Disp.SetActive(false);
        }
        
    }
}
