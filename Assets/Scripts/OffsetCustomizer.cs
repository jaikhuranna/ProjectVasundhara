using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.InputSystem;


public class OffsetCustomizer : MonoBehaviour
{

    public InputActionProperty grabRight;
    public InputActionProperty grabLeft;
    public GameObject lineOfSight;
    public GameObject ui;
    public GameObject text;
    public GameObject titleobj;
    public GameObject title;
    
    private TriggerInputDetector XRInput;
    // Start is called before the first frame update
    void Start()
    {
        titleobj.SetActive(false);
        title.SetActive(false);
        XRInput = FindObjectOfType<TriggerInputDetector>();
        lineOfSight.SetActive(true);
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        var Vinput = XRInput.GetLeftJoyStick().y;
        if ( Vinput != 0 && transform.position.y >= -10.000f && transform.position.y <= 10.000f)
        {
            transform.Translate(new Vector3(0,Vinput/90f,0));
        }
        else if (transform.position.y > 10f)
        {
            var vector3 = transform.position;
            vector3.y = 9.999f;
            transform.position = vector3;
        }
        else if( transform.position.y < -10f )
        {
            var vector3 = transform.position;
            vector3.y = -9.999f;
            transform.position = vector3;
        }

        if (grabRight.action.ReadValue<float>() == 1f || grabLeft.action.ReadValue<float>() == 1f)
        {
            this.enabled = false;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Debug.Log("pressed teri maa bkl");
            lineOfSight.SetActive(false);
            text.SetActive(false);            
            titleobj.SetActive(true);
            title.SetActive(true);
        }
    }
}
