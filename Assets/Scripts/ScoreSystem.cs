using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt;
    public int score;

    public void Start()
    {
        getPoints();
    }

    public void Update()
    {
        Puntuacion.puntuacionTotal = score;
    }

    public void getPoints()
    {
        ScoreTxt.text = Puntuacion.puntuacionTotal.ToString() + "/" + Puntuacion.preguntasTot;
    }
}
