using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderItem : MonoBehaviour
{
    GameController controller;
    PlayerInformation playerInformation;
    PlayerController playerController;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        playerInformation = GetComponent<PlayerInformation>();
        playerController = GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry")) {
            controller.AddCherry(1);
            Destroy(collision.gameObject);
        }
        /*else if (collision.gameObject.CompareTag("Trap"))
        {
            playerInformation.AddDame(1);
        }*/
        else if (collision.gameObject.CompareTag("SavePoint"))
        {
            //Debug.Log();
            controller.SetStartPoint(collision.gameObject.transform.position);
            collision.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       playerController.SetTouchGround(true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerController.SetTouchGround(false);
    }
}
