using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public SceneLoadManager _SceneLoadManager;
    [SerializeField] private ExitWarningConfirmation myExitWarningConfirmation;

    public void mainMenue()
    {
        StartCoroutine(SceneLoad("MainMenu"));
    }

    public void quizScene()
    {
        StartCoroutine(SceneLoad("QuizScene"));
    }

    public void salirIntroScene()
    {
        StartCoroutine(SceneLoad("IntroScene"));
    }

    public void salirMenuPrincipal()
    {
        StartCoroutine(SceneLoad("MainMenu"));
    }

    public void salirJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator SceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(1f);

        if (_SceneLoadManager.transitionAnimator != null)
        {
            _SceneLoadManager.transitionAnimator.Play("CircleExpand", 0, 0f);
            yield return new WaitForSeconds(1f); 
        }

        Loader.LoadScene(sceneName);
    }

    public void confirmationWindow()
    {
        openConfirmationWindow();
    }

    private void openConfirmationWindow()
    {
        myExitWarningConfirmation.gameObject.SetActive(true);
        myExitWarningConfirmation.yesButton.onClick.AddListener(YesClicked);
        myExitWarningConfirmation.noButton.onClick.AddListener(NoClicked);
    }

    private void YesClicked()
    {
        StartCoroutine(SceneLoad("MainMenu"));
    }

    private void NoClicked()
    {
        myExitWarningConfirmation.gameObject.SetActive(false);
    }
}
