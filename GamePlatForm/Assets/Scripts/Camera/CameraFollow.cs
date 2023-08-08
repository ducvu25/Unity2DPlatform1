using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float delay = 10;
    Transform player;
    Vector3 delta;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        delta = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = player.position - delta;
        transform.position = Vector3.Lerp(transform.position, move, delay * Time.deltaTime);  // caajo nhật vị trí
    }
}
