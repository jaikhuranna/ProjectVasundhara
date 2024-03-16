using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagedEnvs : MonoBehaviour
{
    public GameObject water;

    public GameObject stones;

    public GameObject terrain;

    public GameObject Trees;

    public int test;

    public int test2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wateractive()
    {
        water.SetActive(true);
    }
    public void stoneactive()
    {
        stones.SetActive(true);
    }
    public void treeactive()
    {
        Trees.SetActive(true);
    }
    public void soilactive()
    {
        terrain.SetActive(true);
    }
}
