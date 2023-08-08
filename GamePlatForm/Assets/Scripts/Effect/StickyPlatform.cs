using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    bool check;
    AudioController audioController;
    private void Awake()
    {
        check = false;
        audioController = GameObject.FindWithTag("GameController").GetComponent<AudioController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!check)
            {
                audioController.PlaySound((int)SoundEffect.movingPlatform);
                check = true;
            }
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            check = false;
        }
    }
}
