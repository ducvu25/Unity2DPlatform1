using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{
    [SerializeField] GameObject goBtnSelect;
    [SerializeField] Transform transIndexParentSelect;

    [SerializeField] Button btnHome;
    bool isActiveBtn = false;
    // Start is called before the first frame update
    void Start()
    {
        int sizeLv = Loadding.instance.GetSize();
        for (int i = 0; i < sizeLv; i++) {
            GameObject go = Instantiate(goBtnSelect);
            int d = Loadding.instance.GetValue(i);
            if (d == -1)
            {
                go.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                go.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                go.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                go.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

                if(d > 0)
                {
                    go.transform.GetChild(0).GetChild(0).GetChild(d-1).gameObject.SetActive(true);
                }
                int d2 = i;
                go.transform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    StartCoroutine(ActiveBtn(d2+1));
                });
            }
            go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Lv " + (i + 1);
            go.transform.parent = transIndexParentSelect;
            go.transform.localScale = Vector3.one * 1.5f;

        }
        btnHome.onClick.AddListener(()=> StartCoroutine(ActiveBtn(-1)));
    }
    IEnumerator ActiveBtn(int i)
    {
        AudioController.instance.PlaySound((int)SoundEffect.button);
        isActiveBtn = true;
        yield return new WaitForSeconds(0.3f);
        isActiveBtn = false;
        AudioController.instance.SetAudio();
        SceneManager.LoadScene(i + (int)INDEX_SCENE.SCENE_SELECT);
    }
}


