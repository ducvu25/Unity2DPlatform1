using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInformation playerInformation = collision.GetComponent<PlayerInformation>();
            if(playerInformation != null)
            {
                playerInformation.Recuperate(1);
                Destroy(gameObject);
            }
        }
    }
}
