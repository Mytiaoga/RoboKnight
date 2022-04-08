using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerTrans;
    SpriteRenderer playerRend;
    Rigidbody2D playerRigid;
    BoxCollider2D playerBox;
    public Animator playerAnim;
    [SerializeField] GameObject land;
    [SerializeField] Camera camPlayer;
    float walk;
    public bool checkJump;
    [SerializeField] Score s;
    FollowCamPlayer fcp;
    LifeCounter lc;
    [SerializeField] GameObject life;
    public bool isControl;
    GameObject lifeAnim;
    bool walkLeft;
    public bool deathOnce;
    scores sco;
    bool play1, play2, play3;

    [Header("Camera")]
    float up, down, left, right;

    [Header("Audio")]
    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip[] ac;

    void Start()
    {
        playerTrans = GetComponent<Transform>();
        //playerAnim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerBox = GetComponent<BoxCollider2D>();
        sco = GameObject.Find("UI/Scores").GetComponent<scores>();
        fcp = GameObject.Find("Camera").GetComponent<FollowCamPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        lc = GameObject.Find("LifeCount").GetComponent<LifeCounter>();
        lifeAnim = GameObject.Find("LifeCount");
        if (!isControl)
        {
            playerAnim.SetFloat("Walk", Input.GetAxis("Horizontal"));
            walk = Input.GetAxis("Horizontal") * .015f;
            float walkValue = Input.GetAxis("Horizontal");
            if(walkValue < 0 && !walkLeft)
            {
                playerTrans.Rotate(new Vector3(0f,180f,0f));
                //playerTrans.Translate(walk, 0, 0);
                walkLeft = true;
            }
            else if(walkValue > 0 && walkLeft)
            {
                playerTrans.Rotate(new Vector3(0f, -180f, 0f));
                //playerTrans.Translate(-walk, 0, 0);
                walkLeft = false;
            }
            if (!walkLeft)
            {
                if (play1)
                {
                    aud.clip = ac[0];
                    aud.Play();
                    play1 = false;
                }

                playerTrans.Translate(walk, 0, 0);
            }
            else if (walkLeft)
            {
                if (!play1)
                {
                    aud.clip = ac[0];
                    aud.Play();
                    play1 = true;
                }
                playerTrans.Translate(-walk, 0, 0);
            }
            if(walkValue == 0)
            {
                aud.Stop();
            }

            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walk = Input.GetAxis("Horizontal") * .02f;
                playerAnim.SetBool("Sprint", true);
                if (!walkLeft)
                {
                    if (play3)
                    {
                        aud.clip = ac[2];
                        aud.Play();
                        play3 = false;
                    }
                    playerTrans.Translate(walk, 0, 0);
                }
                else
                {
                    if (!play3)
                    {
                        aud.clip = ac[2];
                        aud.Play();
                        play3 = true;
                    }
                    playerTrans.Translate(-walk, 0, 0);
                }

            }
            else
            {
                playerAnim.SetBool("Sprint", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && !checkJump && !(Input.GetKey(KeyCode.S)))
            {
                playerAnim.SetTrigger("Jump");
                playerAnim.SetBool("Land", false);
                playerRigid.AddForce(Vector2.up * 600);
                checkJump = true;
            }
            if (checkJump)
            {
                aud.Stop();
            }
            if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                land.SetActive(false);
            }
            if(walk != 0)
            {
                playerAnim.SetBool("Add_Walk", true);
            }
            else
            {
                playerAnim.SetBool("Add_Walk", false);
            }


            //Camera
            //if(Input.GetKey(KeyCode.I))
            //{

            //   if(up < 2f)
            //   {
            //        up = up + .08f;
            //        camPlayer.GetComponent<Transform>().position = new Vector3(camPlayer.GetComponent<Transform>().position.x, up, camPlayer.GetComponent<Transform>().position.z);
            //    }
            //}
            //if (!(Input.GetKey(KeyCode.I)))
            //{

            //    if(up >= 0)
            //    {
            //        up = up - .08f;
            //        camPlayer.GetComponent<Transform>().position = new Vector3(camPlayer.GetComponent<Transform>().position.x, up, camPlayer.GetComponent<Transform>().position.z);
            //    }

            //}


            //if (Input.GetKey(KeyCode.K))
            //{

            //    if (down < 2f)
            //    {
            //        down = down + .08f;
            //        camPlayer.GetComponent<Transform>().position = new Vector3(camPlayer.GetComponent<Transform>().position.x, -down, camPlayer.GetComponent<Transform>().position.z);
            //    }
            //}
            //if (!(Input.GetKey(KeyCode.K)))
            //{

            //    if (down >= 0)
            //    {
            //        down = down - .08f;
            //        camPlayer.GetComponent<Transform>().position = new Vector3(camPlayer.GetComponent<Transform>().position.x, -down, camPlayer.GetComponent<Transform>().position.z);
            //    }
            //}


            if (playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Win"))
            {
                sco.exit();
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkJump = false;
        playerAnim.SetBool("Land", true);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerAnim.SetBool("Land", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bounds")
        {
            fcp.fell = true;
        }

        if(collision.name == "DeSpawner")
        {
            lc.lifeCount--;
            life.GetComponent<Animator>().SetTrigger("dead");
            Destroy(this.gameObject);
        }

        if(collision.tag == "obstacle" && !deathOnce)
        {
            if (!play2)
            {
                aud.clip = ac[1];
                aud.Play();
                play2 = true;
            }
            playerRigid.AddForce(new Vector2(-100f,0f));
            playerAnim.SetFloat("Walk", 0);
            playerAnim.SetBool("Sprint", false);
            playerAnim.SetTrigger("Hit");
            playerAnim.SetBool("Death", true);
            isControl = true;
            deathOnce = true;
            lc.lifeCount--;
            lifeAnim.GetComponent<LifeCounter>().DeathAnim();   
        }
    }


}
