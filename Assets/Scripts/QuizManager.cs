using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;


    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    public int totalQuestions = 0;

    ScoreSystem scoreSystem;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            instance.SetManagers();
        }
        else
        {
            instance = this;
            SetManagers();
        }

    }

    private void Start()
    {
        totalQuestions = QnA.Count;
        generateQuestion();
    }

    public void SetManagers()
    {
        if (scoreSystem == null)
        {
            ScoreSystem scoreSystemInstance = FindObjectOfType<ScoreSystem>();
            scoreSystem = scoreSystemInstance;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Puntuacion.preguntasTot = totalQuestions;

    }

    public void correct()
    {
        scoreSystem.score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersManager>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswersManager>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
        
    }
}
