using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] bool dummyActivation;
    public TMP_Text life;
    public TMP_Text dummy;
    public int lifeCount;
    public int lifeDummy;
    Controls player;
    Animator gameOver;

    [Header("some stuff")]
    public bool isDead;
    Animator lifeCounter;
    public int time;

    [Header("for cutscenes")]
    TimeLineScript tls;
    public bool firstGame;

    public static LifeCounter lifeInstance;
    void Start()
    {
        if (!dummyActivation)
        {
            player = GameObject.Find("Robo_Knight").GetComponentInChildren<Controls>();
            lifeDummy = lifeCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dummyActivation)
        {
            life = GameObject.Find("UI/Life/lifeCount").GetComponent<TMP_Text>();
            dummy = GameObject.Find("UI/Life/dummyCount").GetComponent<TMP_Text>();
            life.text = lifeCount.ToString();
            dummy.text = lifeDummy.ToString();
            lifeCounter = GameObject.Find("UI/Life").GetComponent<Animator>();
            if (lifeCount == 0)
            {
                isDead = true;
                time++;
            }
            if (time > 2000)
            {
                Destroy(this.gameObject);
                Loader.Load(Loader.Scene.TitleScreen);
            }
        }
        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        if (!dummyActivation)
        {
            if(SceneManager.GetActiveScene().name != "TitleScreen")
            {
                DontDestroyOnLoad(this.gameObject);
                if (lifeInstance == null)
                {
                    lifeInstance = this;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            
        }
    }

    public void restart()
    {
        lifeDummy--;
        if (!isDead)
        {
            Loader.Load(Loader.Scene.MainGame);
        }
        if (isDead)
        {
            theEnd();
        }

    }

    public void DeathAnim()
    {
        lifeCounter.SetTrigger("dead");
    }

    public void theEnd()
    {
        Debug.Log("WHAT");
        gameOver = GameObject.Find("UI/GameOver").GetComponent<Animator>();
        gameOver.SetTrigger("done");
    }
}
