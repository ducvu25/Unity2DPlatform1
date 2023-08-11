using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float forceJump = 4f;

    [SerializeField] LayerMask jumpableGround;

    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator ani;
    BoxCollider2D coll;
    AudioController audioController;
    GhostController ghostController;
    enum MovementState { idle, running, jumping, falling, doubleJump}

    float speedMultiplier;
    bool doubleJump = true;
    float move_x;
    bool touchGround;
    private void Awake()
    {
        touchGround = false;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();    
        ani = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        ghostController = GetComponent<GhostController>();
        audioController = GameObject.FindWithTag("GameController").GetComponent<AudioController>();
        doubleJump = false;
        speedMultiplier = speed;
    }
    private void Update()
    {
        Run();
        Jump();
        UpdateAnimation();
    }
    /*private void FixedUpdate()
    {
        //float targetSpeed = speed * speedMultiplier;
        //rb.velocity = new Vector2 (targetSpeed, rb.velocity.y);
        Jump();
    }*/
    void Run()
    {
        move_x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move_x * speedMultiplier, rb.velocity.y);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGround() || touchGround)
            {
                doubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, forceJump);
                audioController.PlaySound((int)SoundEffect.jump);
            }
            else if(doubleJump)
            {
                doubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, forceJump *0.75f);
                audioController.PlaySound((int)SoundEffect.jump);
            }
        }
    }
    void UpdateAnimation()
    {

        ghostController.check = false;
        MovementState state;// = MovementState.idle;
        if (move_x > 0)
        {
            sp.flipX = false;
            state = MovementState.running;
        }
        else if (move_x < 0)
        {
            sp.flipX = true;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            if (doubleJump)
            {
                state = MovementState.jumping;
            }
            else
            {
                ghostController.check = true;
                state = MovementState.doubleJump;
            }
        }else if(rb.velocity.y < -0.1f)
        {
            ghostController.check = true;
            state = MovementState.falling;
            if(rb.velocity.y > -30)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.05f);//Mathf.Max(rb.velocity.y, ))
        }
        ani.SetInteger("state", (int)state);
    }
    bool IsGround()
    {
        if (!touchGround && Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, jumpableGround))
            touchGround = true;
        return touchGround;
    }
    public void UpdateAnimationTrigger(int value)
    {
        switch (value)
        {
            case 0:
                {
                    ani.SetTrigger("Hit");
                    break;
                }
            case 1:
                {
                    audioController.PlaySound((int)SoundEffect.death);
                    ani.SetTrigger("Death");
                    break;
                }
        }
    }
    public void AddFoce(Vector2 value)
    {
        rb.velocity = value; // new Vector2(rb.velocity.x, value);
        if(value.y > 0 && !doubleJump)
            doubleJump = true;
    }
    public void SetTouchGround(bool value)
    {
        touchGround = value;
    }
}
