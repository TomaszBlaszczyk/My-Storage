using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public Image loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGameOperation());
    }

    IEnumerator LoadGameOperation()
    {
        AsyncOperation loadingLevel = SceneManager.LoadSceneAsync(2);

        while (loadingLevel.progress < 1)
        {
            loadingBar.fillAmount = loadingLevel.progress;
            yield return new WaitForEndOfFrame();
        }


    }
}
