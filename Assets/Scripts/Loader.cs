using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Slider loadingBar;
    public float simulatedLoadTime = 3.0f; // Tiempo de carga simulado

    // Variable estática para determinar qué escena cargar después del Loader
    public static string nextSceneToLoad;

    private void Start()
    {
        StartCoroutine(SimulatedLoadSceneAsync(nextSceneToLoad));
    }

    private IEnumerator SimulatedLoadSceneAsync(string sceneName)
    {
        // Esperar 2 segundos antes de iniciar la carga
        yield return new WaitForSeconds(1.0f);

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

    // Método para llamar cuando quieras cambiar de escena
    public static void LoadScene(string sceneName)
    {
        nextSceneToLoad = sceneName;
        SceneManager.LoadScene("Loader");
    }
}
