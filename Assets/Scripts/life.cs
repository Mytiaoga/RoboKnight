using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    LifeCounter lc;
    void Start()
    {
        lc = GameObject.Find("LifeCount").GetComponent<LifeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        lc.restart();
    }
}
