using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoSceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; 
    public float delay = 4.0f; // Tiempo de espera en segundos antes de cambiar de escena.

    private void Start()
    {
        StartCoroutine(SwitchSceneAfterDelay());
    }

    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad);
    }
}
