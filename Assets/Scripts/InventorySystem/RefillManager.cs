using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    public string HolderName;
    private Vector3 HoldingPosition;

    public bool Dict;

    public void InitElement(bool crafted)
    {
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
            if (Vector3.Distance(transform.position, HoldingPosition) > 0.5f)
            {
                var NewElement = Instantiate(this , HoldingPosition, Quaternion.identity);
                NewElement.InitElement(false);
                this.enabled = false;
            }
        }
    }
}
