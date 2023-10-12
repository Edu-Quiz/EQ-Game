using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{

    [SerializeField] private ExitWarningConfirmation myExitWarningConfirmation;

    public void mainMenue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quizScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void salirIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void salirJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void NoClicked()
    {
        myExitWarningConfirmation.gameObject.SetActive(false);
    }

}