using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : GeneralAnimation
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        StatSetting(100, 10, 7, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*Stats.MoveSpeed,rb.velocity.y,0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            StateUpdate(CharacterStates.Run);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StateUpdate(CharacterStates.Jump);
            rb.velocity = Vector2.up * Stats.JumpForce;
        }
        if (!Input.anyKey&&rb.velocity == Vector2.zero)
        {
            StateUpdate(CharacterStates.Idle);
        }
    }
}
