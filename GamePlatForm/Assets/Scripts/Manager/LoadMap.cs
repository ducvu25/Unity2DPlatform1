using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMap : MonoBehaviour
{
    public void LoadScene(int value)
    {
        SceneManager.LoadScene(value);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Restart(float time = 0f)
    {
        Invoke("Restart", time);
    }
    void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
