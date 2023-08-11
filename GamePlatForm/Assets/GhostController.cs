using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] GameObject ghost;
    SpriteRenderer sprite;
    float m_delay = 0;
    public bool check;
    private void Start()
    {
        check = false;
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (check)
        {
            if(m_delay > 0)
            {
                m_delay -= Time.deltaTime;
            }
            else
            {
                m_delay = delay;
                GameObject newGhost = Instantiate(ghost, transform.position, transform.rotation);
                SpriteRenderer sprtieGhost = newGhost.GetComponent<SpriteRenderer>();
                sprtieGhost.sprite = sprite.sprite;
                if (sprite.flipX)
                {
                    sprtieGhost.flipX = true;
                }
                else
                {
                    sprtieGhost.flipX= false;
                }
            }
        }
    }
}
