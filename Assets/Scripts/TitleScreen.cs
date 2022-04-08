using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    GameObject settings;
    GameObject title;
    void Start()
    {
        settings = GameObject.Find("Canvas/Settings");
        title = GameObject.Find("Canvas/Title");
        settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBTN()
    {
        Loader.Load(Loader.Scene.MainGame);
    }

    public void SettingsBTN()
    {
        title.SetActive(false);
        settings.SetActive(true);
    }

    public void TitleBTN()
    {
        title.SetActive(true);
        settings.SetActive(false);
    }

    public void ExitBTN()
    {
        Application.Quit();
    }
}
