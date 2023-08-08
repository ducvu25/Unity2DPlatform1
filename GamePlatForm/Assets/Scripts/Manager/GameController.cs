using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] Text txtCherryNumber;
    int nCherry;
    Vector3 startPoint;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        nCherry = 0;
        txtCherryNumber.text = "Cherry: " + nCherry.ToString();
        startPoint = GameObject.FindWithTag("StartPoint").transform.position;
        player = GameObject.FindWithTag("Player");
        player.transform.position = startPoint;
        //startPoint = player.transform.position;
        GameObject.FindWithTag("MainCamera").transform.position = new Vector3(startPoint.x, startPoint.y, GameObject.FindWithTag("MainCamera").transform.position.z);
    }
    public void AddCherry(int count)
    {
        nCherry += count;
        txtCherryNumber.text = "Cherry: " + nCherry.ToString();
    }
    public void SetStartPoint(Vector3 pos)
    {
        startPoint = pos;
    }
    public void BackToPosition()
    {
        player.transform.position = startPoint;
    }
}
