using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCtrl : GeneralAnimation
{
    Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    public bool attackAble = true;
    public float MoveSpeed;
    public short plrHead = 1;
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
        if (Input.GetKeyDown(KeyCode.C) && attackAble)
        {
            attackAble = false;
            rb.velocity = Vector3.zero;
            StartCoroutine(AtackTimer());
        }
        if (!attackAble)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);
        }
        if (attackAble)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
            if (rb.velocity.x != 0)
            {
                if (rb.velocity.x > 0)
                {
                    plrHead = 1;
                    anim.SetBool("Run", true);
                    sr.flipX = false;
                }
                if (rb.velocity.x < 0)
                {
                    plrHead = -1;
                    anim.SetBool("Run", true);
                    sr.flipX = true;
                }
            }
            if (Physics2D.Raycast(transform.position, Vector2.down, 1.7f) && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += Vector2.up * jumpForce;

            }
            if (Input.GetButtonUp("Horizontal"))
            {
                anim.SetBool("Jump", true);

            }
            if (rb.velocity.x == 0)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Jump", false);
            }
        }
    }

    IEnumerator AtackTimer()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.1f);
        float AtkSpeed = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AtkSpeed / 2);
        RaycastHit2D rayHitOBJ = Physics2D.Raycast(transform.position, Vector2.right * plrHead, 2);
        
        yield return new WaitForSeconds((AtkSpeed / 2) - 0.2f);
        
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack", false);
        attackAble = true;
    }
}
