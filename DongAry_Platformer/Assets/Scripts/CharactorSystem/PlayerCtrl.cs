using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : GeneralAnimation
{
    //Rigidbody2D rb;
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


    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StatSetting(100, 10, 7, 10);

    }
    // Update is called once per frame
    void Update()
    {
        if (!attackAble)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Sliding", false);
        }

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * Stats.MoveSpeed, rb.velocity.y, 0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            StateUpdate(CharacterStates.Run);
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
            if (rb.velocity.x == 0)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Sliding", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateUpdate(CharacterStates.Jump);
            rb.velocity = Vector2.up * Stats.JumpForce;
            anim.SetBool("Jump", true);

        }
        

        if (!Input.anyKey && rb.velocity == Vector2.zero)
        {
            StateUpdate(CharacterStates.Idle);
        }

   
    }

}
