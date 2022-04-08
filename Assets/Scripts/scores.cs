using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scores : MonoBehaviour
{
    public TMP_Text score;
    public Score s;
    public LifeCounter lc;
    void Start()
    {
        score = GameObject.Find("UI/Scores/scoreDisplay").GetComponent<TMP_Text>();
        s = GameObject.Find("Score_obj").GetComponent<Score>();
        lc = GameObject.Find("LifeCount").GetComponent<LifeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = s.actualScore.ToString();
    }

    public void title()
    {
        Destroy(lc.gameObject);
        Loader.Load(Loader.Scene.TitleScreen);
    }

    public void exit()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("tally");
    }
}
