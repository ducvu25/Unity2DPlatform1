using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField] float speedRotaion = 2f;
    [SerializeField] int dame = 1;
    //CircleCollider2D circleCollider;
    float time_spawn = 0.5f;
    float m_time_spawn = 0;

    AudioController audioController;
    private void Start()
    {
        //   circleCollider = GetComponent<CircleCollider2D>();

        audioController = GameObject.FindWithTag("GameController").GetComponent<AudioController>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360*speedRotaion*Time.deltaTime);
        if(m_time_spawn > 0 )
            m_time_spawn -= Time.deltaTime;
       /* else
        {
            circleCollider.enabled = true;
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && m_time_spawn <= 0)
        {
            PlayerInformation playerInformation = collision.GetComponent<PlayerInformation>();
            if(playerInformation != null)
            {
                playerInformation.AddDame(dame);
                audioController.PlaySound((int)SoundEffect.saw);
            }
            else
            {
                Debug.Log("Character collision error!");
            }
            m_time_spawn = time_spawn;
        }

    }

}
