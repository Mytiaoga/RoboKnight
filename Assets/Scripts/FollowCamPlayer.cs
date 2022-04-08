using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bounds;
    public bool fell;
    void Start()
    {
        fell = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fell)
        {
            this.gameObject.GetComponent<Transform>().transform.position = 
            new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y, -5.5178f);
        }
    }
}
