using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    public string HolderName;
    private Vector3 HoldingPosition;
    public GameObject SelfObject;

    public bool Dict;

    public void InitElement(bool crafted)
    {
        // GetComponent<Rigidbody>().drag = 2.5f;
        // GetComponent<Rigidbody>().angularDrag = 1;
        if (crafted)
        {
            this.enabled = false;
            Dict = false;
        }
        else
        {
            HoldingPosition = GameObject.Find(HolderName).transform.position;
            Dict = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Dict)
        {
            //Debug.Log(HoldingPosition);
            if (Vector3.Distance(transform.position, HoldingPosition) > 0.3f)
            {
                var NewElement = Instantiate(SelfObject , HoldingPosition, Quaternion.identity);
                NewElement.GetComponent<RefillManager>().InitElement(false);
                GetComponent<Rigidbody>().isKinematic = false;
                this.enabled = false;
            }
        }
    }
}
