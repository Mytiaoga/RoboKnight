using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineScript : MonoBehaviour
{
    PlayableDirector play;
    Controls player;
    [SerializeField] GameObject boulder_1, boulder_2, UI;
    LifeCounter lc;

    void Start()
    {
        player = GameObject.Find("Robo_Knight/GameObject").GetComponent<Controls>();
        lc = GameObject.Find("LifeCount").GetComponent<LifeCounter>();
        play = this.gameObject.GetComponent<PlayableDirector>();
        play.stopped += Play_stopped;
        player.isControl = true;
    }

    public void Play_stopped(PlayableDirector obj)
    {
        boulder_1.SetActive(true);
        boulder_2.SetActive(true);
        UI.SetActive(true);
        player.isControl = false;
        lc.firstGame = true;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            play.Stop();
        }   
        if(lc.firstGame == true)
        {
            play.Stop();
        }
    }

    public void staph()
    {
        play.Stop();
    }
}
