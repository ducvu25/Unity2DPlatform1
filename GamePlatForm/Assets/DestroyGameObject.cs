using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnDestroy", time);
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
