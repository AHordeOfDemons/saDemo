using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyer : MonoBehaviour
{
    public float speed;
    private bool fireing = false;

    private bool fireok = true;

    public float jump1;
    bool isground;
    int jumpcount;
    bool jumpPressed;

    public Transform groundcheck;
    public LayerMask ground;


    private Animator anim;
    private Rigidbody2D rb;

 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animplayer();
        
        fire();

        if (Input.GetButtonDown("Jump") && jumpcount > 0)
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        move();
        jump();
        isground = Physics2D.OverlapCircle(groundcheck.position, 0.1f, ground);
    }


    void move()
    {
        if (fireing)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            float horizontalmove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            if (horizontalmove != 0)//  && fireing
            {
                transform.localScale = new Vector3(horizontalmove, 1, 1);
            }
        }
    }

    void jump()   
    {
        if (isground)
        {
            jumpcount = 1;//可跳跃数量
        }
        if (jumpPressed && jumpcount > 0)
        {

            rb.velocity = new Vector2(rb.velocity.x, jump1);
            jumpcount--;
            jumpPressed = false;
        }


    }

    void fire()
    {
        if (Input.GetButtonDown("Fire1") && fireok)
        {
            fireing = true;
            transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("daoguang").GetComponent<fire>().fire1(transform.localScale.x);
            anim.SetTrigger("fire");

            fireok = false; //延时控制攻击间隔
            Invoke("fire1", 1.0f);
            Invoke("fire2", 0.3f);
        }
    }
    void fire1()
    {
        fireok = true;
    }
    void fire2()
    {
        fireing = false;
    }


    void animplayer()
    {
        anim.SetFloat("速度", Mathf.Abs(rb.velocity.x));


        if (isground)
        {
            anim.SetBool("falling", false);
        }
        else if (!isground && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }
}
