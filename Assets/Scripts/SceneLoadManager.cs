using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private float transitionTime = 3.0f;
    [SerializeField] private float delayBeforeTransition = 1.0f; // Tiempo de espera antes de iniciar la transici�n

    [SerializeField] private Animator transitionAnimator;  // Referencia al Animator

    private void Start()
    {
        // Si transitionAnimator no est� asignado
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
            Debug.LogError("No se encontr� un componente Animator. Aseg�rate de asignarlo o agregarlo al GameObject.");
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
        yield return new WaitForSeconds(delayBeforeTransition); // Espera antes de iniciar la transici�n

        transitionAnimator.SetTrigger("Close"); // Inicia la animaci�n de cerrar
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
