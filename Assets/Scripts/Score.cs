using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int CogsScore;
    public int actualScore;

    public static Score scoreInstance;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        //if (scoreInstance == null)
        //{
        //    scoreInstance = this;
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }

    /*  
     Score = Time remaining * Lives Remaining * .02f(?)
     */

  
}


