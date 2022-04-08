using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlatformEffector2D platEffect;
    public float waitTime;
    [SerializeField] Controls player;
    void Start()
    {
        platEffect = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    platEffect.rotationalOffset = 0f;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platEffect.rotationalOffset = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            //waitTime = .5f;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            //if (waitTime <= 0)
            //{
                platEffect.rotationalOffset = 180f;
                //waitTime = .5f;
            //}
            //else
            //{
            //    waitTime = 0;
            //}
        }
    }
}
