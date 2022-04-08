using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_trigger : MonoBehaviour
{
    Animator obstacleAnim;
    public int timer;
    [SerializeField] bool s1, s2, s3, s4;
    GameObject warning;
    Controls player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Robo_Knight/GameObject").GetComponent<Controls>();
        if (s1)
        {
            obstacleAnim = GameObject.Find("Spike").GetComponent<Animator>();
        }
        if (s2)
        {
            obstacleAnim = GameObject.Find("Spike (1)").GetComponent<Animator>();
        }
        if (s3)
        {
            obstacleAnim = GameObject.Find("Spike (2)").GetComponent<Animator>();
        }
        if (s4)
        {
            obstacleAnim = GameObject.Find("Spike (3)").GetComponent<Animator>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        warning = GameObject.Find("Robo_Knight/GameObject/warning");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            timer++;
            if(timer > 10)
            {
                if (!player.deathOnce)
                {
                    warning.SetActive(true);
                }
            }
            if (timer > 30)
            {
                obstacleAnim.SetTrigger("step");
                timer = 0;
                warning.SetActive(false);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 0;
        warning.SetActive(false);
    }
}
