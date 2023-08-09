using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallController : MonoBehaviour
{
    [SerializeField] float force = 10f;
    [SerializeField] int dame = 1;
    Rigidbody2D rb;
    bool right;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       int x = (int)Random.Range(0, 2);
        if (x == 0)
            right = true;
        else
            right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x == 0)
        {
            if (right)
                rb.AddForce(Vector2.right * force);
            else
                rb.AddForce(Vector2.left * force);
        }
        if (rb.velocity.y == 0)
            right = !right;
        //Debug.Log(rb.velocity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && player == null)
        {
            player = collision.gameObject;
            if (right)
                collision.gameObject.GetComponent<PlayerController>().AddFoce(Vector2.right * force/5);
            else
                collision.gameObject.GetComponent<PlayerController>().AddFoce(Vector2.left * force/5);
            Invoke("AddDame", 0.75f);
        }
    }
    void AddDame()
    {
        player.GetComponent<PlayerInformation>().AddDame(dame);
        player = null;
    }
}
