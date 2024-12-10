using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel_Preguntas : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler OnEndGame;

    public delegate void Result(bool isCorrect);
    public event Result OnResult;

    [SerializeField] textQuestion txtQ;
    [SerializeField] textTimer txtT;
    [SerializeField] triggerController1 triggerController;

    List<Question> questions = new List<Question>();
    TextMeshPro txtQuestion;
    int auxCount, answer, correctAnswers;

    public int getCorrectAnswers()
    {
        return correctAnswers;
    }

    struct Question
    {
        public string question;
        public int correctAnswer;
    }

    private void Awake()
    {
        txtQuestion = txtQ.GetComponent<TextMeshPro>();
    }

    void Start()
    {
        auxCount = 0;
        answer = -1;
        correctAnswers = 0;
        questions.Add(new Question { question = "¿El cielo es azul durante el día?", correctAnswer = 1 });
        questions.Add(new Question { question = "Los gatos pueden volar.", correctAnswer = 0 });
        questions.Add(new Question { question = "El agua hierve a 100 grados Celsius.", correctAnswer = 1 });
        questions.Add(new Question { question = "El chocolate es venenoso para los perros.", correctAnswer = 1 });
        questions.Add(new Question { question = "Las arañas son insectos.", correctAnswer = 0 });
        txtQ.Continuar += Comenzar;
        txtT.TimeOut += Comprobar;
    }

    void Comenzar()
    {
        if (auxCount < questions.Count)
        {
            txtQuestion.text = questions[auxCount].question;
            auxCount++;
        } else
        {
            OnEndGame?.Invoke();
        }
    }

    void Comprobar()
    {
        answer = triggerController.getOption();

        if (answer == questions[auxCount - 1].correctAnswer)
        {
            OnResult?.Invoke(true);
            correctAnswers++;
        }
        else
        {
            OnResult?.Invoke(false);
        }
    }

    private void OnDisable()
    {
        txtQ.Continuar -= Comenzar;
        txtT.TimeOut -= Comprobar;
    }
}
