using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Slider loadingBar;
    public float simulatedLoadTime = 3.0f; // Tiempo de carga simulado

    public static string nextSceneToLoad;

    private void Start()
    {
        StartCoroutine(DelayBeforeLoad());
    }

    private IEnumerator DelayBeforeLoad()
    {
        yield return new WaitForSeconds(1f);  // Espera 1 segundos antes de comenzar
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
