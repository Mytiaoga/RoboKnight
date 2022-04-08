using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float sec;
    [SerializeField] float min;
    public float timeRemaining;
    [SerializeField] TMP_Text time;
    public int seconds;
    public int minutes;

    // Start is called before the first frame update
    void Start()
    {
        sec = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {

        if (sec != 0)
        {
            sec -= Time.deltaTime;
            seconds = Mathf.FloorToInt(sec % 60);
            minutes = Mathf.FloorToInt(sec / 60);
            time.text = string.Format("{0}:{1:00}", minutes, seconds);
        }
        if (sec < 0)
        {
            sec = timeRemaining;
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }


}