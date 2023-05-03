using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float MoveSpeed;
    private Animator anim;
    public AnimationClip AtkAnim;
    public bool attackAble = true;
    public LayerMask isGround;
    public LayerMask monsterLayer;
    public float jumpForce;
    public short plrHead = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
            anim.SetBool("Sliding", false);
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
            if (Physics2D.Raycast(transform.position, Vector2.down, 1.7f, isGround) && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += Vector2.up * jumpForce;

            }
            if (Input.GetButtonUp("Horizontal"))
            {
                anim.SetBool("Sliding", true);
            }
            if (rb.velocity.x == 0)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Sliding", false);
            }
        }
    }

    IEnumerator AtackTimer()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.1f);
        float AtkSpeed = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AtkSpeed / 2);
        RaycastHit2D rayHitOBJ = Physics2D.Raycast(transform.position, Vector2.right * plrHead, 2, monsterLayer);
        if (rayHitOBJ.collider != null)
        {
            Debug.Log(rayHitOBJ.collider.name);
            rayHitOBJ.collider.GetComponent<Monster>().HP -= 10;
        }
        yield return new WaitForSeconds((AtkSpeed / 2) - 0.2f);
        if (rayHitOBJ.collider != null)
        {
            Debug.Log(rayHitOBJ.collider.name);
            rayHitOBJ.collider.GetComponent<Monster>().HP -= 10;
        }
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack", false);
        attackAble = true;
    }
}
