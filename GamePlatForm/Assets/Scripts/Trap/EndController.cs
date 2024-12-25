using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(EndGame(collision.transform));
        }
    }
    IEnumerator EndGame(Transform player)
    {
        endGame = true;
        animator.SetTrigger("Finish");
        audioController.PlaySound((int)SoundEffect.finish);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Loadding.instance.OpenMap(currentSceneIndex - (int)INDEX_SCENE.SCENE_LV_1, 3);
        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        AudioController.instance.SetAudio();
        loadMap.LoadScene(1);
    }
}
