using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDictionary : MonoBehaviour
{
    public List<RefillManager> DictOptions;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var ele in DictOptions)       
        {
            ele.InitElement(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
