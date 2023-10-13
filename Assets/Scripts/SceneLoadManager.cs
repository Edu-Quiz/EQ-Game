using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private float transitionTime = 3.0f;
    [SerializeField] private float delayBeforeTransition = 1.0f; // Tiempo de espera antes de iniciar la transición

    [SerializeField] private Animator transitionAnimator;  // Referencia al Animator

    private void Start()
    {
        // Si transitionAnimator no está asignado
        if (transitionAnimator == null)
        {
            transitionAnimator = GetComponent<Animator>();
        }

        if (transitionAnimator == null)
        {
            transitionAnimator = GetComponentInChildren<Animator>();
        }

        if (transitionAnimator == null)
        {
            Debug.LogError("No se encontró un componente Animator. Asegúrate de asignarlo o agregarlo al GameObject.");
            return;
        }

        transitionAnimator.SetTrigger("Open");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        yield return new WaitForSeconds(delayBeforeTransition); // Espera antes de iniciar la transición

        transitionAnimator.SetTrigger("Close"); // Inicia la animación de cerrar
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
