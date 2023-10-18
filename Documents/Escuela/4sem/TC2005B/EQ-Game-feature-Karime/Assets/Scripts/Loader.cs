using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Slider loadingBar;
    public float simulatedLoadTime = 3.0f;
    public Animator transitionAnimator;

    public static string nextSceneToLoad;

    private void Start()
    {
        StartCoroutine(SceneLoad());
    }

    private IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(Mathf.Max(simulatedLoadTime, 4f));

        if (transitionAnimator != null)
        {
            transitionAnimator.Play("CircleExpand", 0, 0f);
            yield return new WaitForSeconds(1f); 
        }

        StartCoroutine(SimulatedLoadSceneAsync(nextSceneToLoad));
    }

    private IEnumerator SimulatedLoadSceneAsync(string sceneName)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < simulatedLoadTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / simulatedLoadTime);
            loadingBar.value = progress;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    public static void LoadScene(string sceneName)
    {
        nextSceneToLoad = sceneName;
        SceneManager.LoadScene("Loader");
    }
}
