using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderItem : MonoBehaviour
{
    GameController controller;
    PlayerInformation playerInformation;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        playerInformation = GetComponent<PlayerInformation>();
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
}
