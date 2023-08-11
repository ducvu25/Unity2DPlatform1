using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class StructionboardController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtMess;
    [SerializeField] string mess = "messenger";
    GameObject canvas;
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        txtMess.text = mess;
        canvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
}
