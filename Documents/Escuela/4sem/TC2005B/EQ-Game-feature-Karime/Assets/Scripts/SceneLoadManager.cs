using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private float transitionTime = 3.0f;
    [SerializeField] private float delayBeforeTransition = 1.0f;
    [SerializeField] public Animator transitionAnimator;

    private void Start()
    {
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
        yield return new WaitForSeconds(delayBeforeTransition);

        //transitionAnimator.SetTrigger("StartTransition"); 
        transitionAnimator.Play("CircleExpand",0,0f);
        yield return new WaitForSeconds(transitionTime);   
        //SceneManager.LoadScene(sceneIndex);
    }
}
