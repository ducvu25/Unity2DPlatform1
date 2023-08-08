using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RockHead : MonoBehaviour
{
    [SerializeField] int dame = 1;

    [SerializeField] LayerMask jumpableGround;
    [SerializeField] GameObject[] Points;
    [SerializeField] float speedMin = 2f;
    [SerializeField] float speedMax = 3f;
    [SerializeField] [Range(0f, 30f)] float deltaSpeed = 100f;
    int currNext = 0;
    float speed;
    bool touchGround = false;
    bool crush_the_player = false;

    AudioController audioController;
    BoxCollider2D coll;
    Animator animator;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioController = GameObject.FindWithTag("GameController").GetComponent<AudioController>();
        player = GameObject.FindWithTag("Player");
        speed = speedMin;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGround() && !touchGround)
        {
            audioController.PlaySound((int)SoundEffect.boxJump);
            currNext = (currNext + 1) % Points.Length;
            touchGround = true;
            animator.SetTrigger("Jump");
            if (crush_the_player)
            {
                PlayerInformation playerInformation = player.GetComponent<PlayerInformation>();
                playerInformation.AddDame(dame);
                crush_the_player = false;
            }
        }
        else
        {
            if (Vector2.Distance(Points[currNext].transform.position, transform.position) < 0.1f)
            {
                currNext = (currNext + 1) % Points.Length;
            }
            else
            {
                touchGround = false;
                if (transform.position.x < Points[currNext].transform.position.x && speed > speedMin)
                {
                    speed -= deltaSpeed * Time.deltaTime;
                }
                else if (transform.position.x > Points[currNext].transform.position.x && speed < speedMax)
                {
                    speed += deltaSpeed * Time.deltaTime;
                }
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Points[currNext].transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            crush_the_player = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            crush_the_player = false;
        }
    }
    bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, jumpableGround);
    }
}
