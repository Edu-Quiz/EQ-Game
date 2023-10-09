using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
        generateQuestion();

    }
    public void correct()
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
        }
        
    }
}
