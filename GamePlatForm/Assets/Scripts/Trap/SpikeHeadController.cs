using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadController : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float gravity = 5f;
    [SerializeField] int dame = 1;
    Rigidbody2D rb;
    bool isFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //boxCollider2D = GetComponent<BoxCollider2D>();
        rb.gravityScale = 0;
        Debug.DrawRay(transform.position, Vector2.down * 5, Color.red);
    }
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (!isFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down*distance, Color.red);

            if(hit.transform != null && hit.transform.tag == "Player")
            {
                rb.gravityScale = gravity;
                isFalling = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetTrigger("Jump");
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerInformation>().AddDame(dame);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
