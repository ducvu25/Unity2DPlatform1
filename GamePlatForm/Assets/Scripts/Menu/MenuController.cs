using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum INDEX_SCENE
{
    SCENE_MENU,
    SCENE_SELECT,
    SCENE_LV_1,
    SCENE_LV_2
}
public class MenuController : MonoBehaviour
{
    [SerializeField] Button btnStart;
    [SerializeField] Button btnAbout;
    [SerializeField] Button btnExit;

    [SerializeField] GameObject goAbout;

    bool isActiveBtn = false;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(goAbout, new Vector3(0, 0, 0), 0f);
        btnStart.onClick.AddListener(() =>
        {
            StartCoroutine(ActiveBtn(0));
        });
        btnAbout.onClick.AddListener(() =>
        {
            StartCoroutine(ActiveBtn(1));
        });
        btnExit.onClick.AddListener(() => {
            StartCoroutine(ActiveBtn(2));
        });
    }

    IEnumerator ActiveBtn(int i)
    {
        AudioController.instance.PlaySound((int)SoundEffect.button);
        isActiveBtn = true;
        yield return new WaitForSeconds(0.3f);
        isActiveBtn = false;
        AudioController.instance.SetAudio();
        switch (i)
        {
            case 0:
                {
                    SceneManager.LoadScene((int)INDEX_SCENE.SCENE_SELECT);
                    break;
                }
            case 1:
                {
                    if (goAbout.activeSelf)
                    {
                        LeanTween.scale(goAbout, new Vector3(0, 0, 0), 0.5f).setOnComplete(() =>
                        {
                            goAbout.SetActive(false);
                        });
                    }
                    else
                    { 
                        goAbout.SetActive(true);
                        LeanTween.scale(goAbout, new Vector3(1, 1, 0), 0.5f);
                    }
                yield return new WaitForSeconds(0.5f);
                break;
                }
            case 2:
                {
                    Application.Quit();
                    break;
                }
        }
    }
}
