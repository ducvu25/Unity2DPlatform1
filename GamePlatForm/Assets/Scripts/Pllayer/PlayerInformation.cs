using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    [SerializeField] GameObject health;
    List<GameObject> healthList;
    int healthCount;

    PlayerController playerController;
    LoadMap loadMap;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        healthList = new List<GameObject> ();
        for(int i=0; i<health.transform.childCount; i++)
        {
            healthList.Add(health.transform.GetChild(i).gameObject);
        }
        healthCount = healthList.Count;

        playerController = GetComponent<PlayerController> ();
        loadMap = GameObject.FindWithTag("GameController").GetComponent<LoadMap>();
        gameController = GameObject.FindWithTag("GameController").GetComponent <GameController>();
    }
    public void AddDame(int value)
    {
        healthCount -= value;
        if (healthCount < 0)
            healthCount = 0;
        for(int i=0; i<value; i++)
        {
            healthList[healthCount +  i].SetActive(false);
        }
        if(healthCount == 0)
        {
            playerController.UpdateAnimationTrigger(1);
        }
        else
        {
            playerController.UpdateAnimationTrigger(0);
            gameController.BackToPosition();
        }
    }
    void NewGame()
    {
        loadMap.Restart();
    }
}
