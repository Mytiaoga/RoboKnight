using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgm : MonoBehaviour
{
    public static bgm instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
                DontDestroyOnLoad(this.gameObject);
                if (instance == null)
                {
                instance = this;
                }
                else
                {
                    Destroy(this.gameObject);
                }
    }
}
