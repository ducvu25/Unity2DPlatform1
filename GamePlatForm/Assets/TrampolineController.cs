using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    [SerializeField] float jumpFoce = 10f;
    
    Animator animator;
    AudioController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GameObject.FindWithTag("GameController").GetComponent<AudioController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (gameObject.transform.GetChild(0).transform.position.y < collision.gameObject.transform.position.y)
            {
                collision.gameObject.transform.SetParent(transform);
                collision.gameObject.GetComponent<PlayerController>().AddFoce(jumpFoce);
                animator.SetTrigger("Jump");
                controller.PlaySound((int)SoundEffect.trampoline);
            }
        }
    }
}
