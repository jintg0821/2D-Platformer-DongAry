using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCtrl : GeneralAnimation
{
    Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    Vector2 velocity;

    public float MoveSpeed;
    public float jumpForce;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        StatSetting(100, 10, 7, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
        if (rb.velocity.x != 0)
        {
            if (rb.velocity.x > 0)
            {
                
                anim.SetBool("Run", true);
                sr.flipX = false;
            }
            if (rb.velocity.x < 0)
            {

                anim.SetBool("Run", true);
                sr.flipX = true;
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jumpForce;
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false); // Jump 상태로 전환할 때 Run 애니메이션을 비활성화
        }

        if (rb.velocity.y == 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", false);
        }


    }

}

    
