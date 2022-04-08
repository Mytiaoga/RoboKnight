using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cogs : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Score s;
    [SerializeField] Timer t;
    [SerializeField] LifeCounter lc;
    [SerializeField] AudioSource aud;
    int holder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            holder = Mathf.RoundToInt(t.timeRemaining * .3f);
            s.actualScore += (100 + (holder * lc.lifeCount));
            s.CogsScore++;
            aud.Play();
            Destroy(this.gameObject);
        }
    }
}
