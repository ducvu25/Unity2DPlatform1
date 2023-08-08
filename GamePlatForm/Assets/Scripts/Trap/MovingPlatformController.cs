using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] GameObject[] Points;
    [SerializeField] float speed = 2f;
    bool reverse = false;
    int currNext = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Points[currNext].transform.position, transform.position) < 0.1f)
        {
            if(!reverse)
                currNext++;
            else currNext--;

            if(currNext == 0 || currNext == Points.Length - 1)
            {
               reverse = !reverse;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Points[currNext].transform.position, speed*Time.deltaTime);

    }
}
