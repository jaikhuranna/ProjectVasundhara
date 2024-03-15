using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StickController : MonoBehaviour
{
    private TriggerInputDetector XRInput;
    private Vector2 JSTA;
    private MeshRenderer show;
    public int spincount;
    public float C;
    private matkaController matka;
    public float dividend;
    private Vector3 initpos;
    void Start()
    {
        initpos = transform.position;
        spincount = 0;
        XRInput = FindObjectOfType<TriggerInputDetector>();
        matka = FindObjectOfType<matkaController>();
        show = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        C = Mathf.Sqrt((JSTA.x * JSTA.x) + (JSTA.y * JSTA.y));
        JSTA = XRInput.GetRightJoyStick();
        if ( C > 0.8f )
        {
            transform.position = new Vector3(JSTA.x/dividend + initpos.x, initpos.y, JSTA.y/dividend +initpos.z);
            
            show.enabled = true;
            if (spincount % 2 == 0)
            {
                if (Mathf.Abs(JSTA.x) > 0.8f)
                {
                    spincount++;
                }
            }
            else
            {
                if (Mathf.Abs(JSTA.y) > 0.8f)
                {
                    spincount++;
                }
            }

            if (spincount == 7)
            {
                matka.CheckIngredients();
                spincount = 0;
            }
        }
        else
        {
            show.enabled = false;
            spincount = 0;
        }
    }
}
