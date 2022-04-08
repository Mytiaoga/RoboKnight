using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCam != null)
        {
            this.gameObject.GetComponent<Camera>().transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y, playerCam.transform.position.z);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        
    }
}
