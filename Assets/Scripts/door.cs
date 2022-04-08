using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] Score s;
    [SerializeField] Controls c;

    [Header("Bars")]
    [SerializeField] GameObject bars;
    [SerializeField] GameObject Up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(s.CogsScore == 3)
        {
            bars.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(s.CogsScore == 3)
        {
            if (collision.tag == "Player")
            {
                Up.SetActive(true);
              
            }
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(s.CogsScore == 3)
        {
            if(collision.tag == "Player")
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    c.playerAnim.SetTrigger("Win");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(s.CogsScore == 3)
        {
            if(collision.tag == "Player")
            {
                Up.SetActive(false);
            }
        }
    }
}


