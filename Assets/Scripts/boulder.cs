using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    public GameObject boul;
    int timer;
    void Start()
    {
        GameObject instance = Instantiate(boul, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                this.gameObject.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer > 800)
        {
            GameObject instance = Instantiate(boul, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                this.gameObject.transform.position.z), Quaternion.identity);
            timer = 0;
        }    
    }

   
}
