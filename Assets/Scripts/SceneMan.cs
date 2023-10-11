using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public void mainMenue()
    {
        SceneManager.LoadScene("MainMenu");
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
}