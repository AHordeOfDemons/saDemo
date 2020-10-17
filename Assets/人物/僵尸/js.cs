using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class js : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject a0;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        move();
    }

    void death(Vector3 attacter)
    {

        anim.SetTrigger("died");

        float coor = transform.position.x - attacter.x;
        if (coor >= 0)
        {
            rb.velocity = new Vector2(10,5);  
        }
        else
        {
            rb.velocity = new Vector2(-10, 5);
        }
        
        
    }

    void rotation()
    {
        transform.rotation =Quaternion.Euler(0, 0, -90);
    }

    void move()
    {
        float mubiao = GameObject.Find("re1").transform.position.x;
        float ziji = transform.position.x;

        float jieguo = mubiao - ziji;

        if(jieguo > 0)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        else
        {
            //  rb.velocity = new Vector2(-4, 0);
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
        
    }

}
