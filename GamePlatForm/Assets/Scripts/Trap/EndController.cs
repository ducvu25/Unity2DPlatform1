using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    LoadMap loadMap;
    AudioController audioController;
    Animator animator;
    bool endGame = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioController = GameObject.FindWithTag("GameController").GetComponent<AudioController>();
        loadMap = GameObject.FindWithTag("GameController").GetComponent<LoadMap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!endGame && collision.tag == "Player")
        {
            endGame = true;
            animator.SetTrigger("Finish");
            audioController.PlaySound((int)SoundEffect.finish);
            loadMap.LoadScene(1);
        }
    }
}
