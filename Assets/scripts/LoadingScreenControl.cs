using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{

    public GameObject loadingScreenObj;
    public Slider slider;

    AsyncOperation async;

    public Image fadeImage;
    public Animator anim;

    public void LoadScreenExample()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(3);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                if (Input.anyKeyDown && slider.value == 1f)
                {
                    StartCoroutine(Fading());
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    IEnumerator Fading ()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
    }

  

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
