using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textTimer : MonoBehaviour
{
    public delegate void EventTime();
    public event EventTime TimeOut;

    [SerializeField] textQuestion txtQ;
    TextMeshPro txtTimer;

    void Start()
    {
        txtTimer = GetComponent<TextMeshPro>();
        txtQ.Continuar += Comenzar;
    }

    void Comenzar()
    {
        StartCoroutine(timer(2));
    }

    IEnumerator timer(int s)
    {
        while (s > -1)
        {
            txtTimer.text = formatTimer(s);
            s--;
            yield return new WaitForSeconds(1.0f);
        }
        TimeOut?.Invoke();
    }

    string formatTimer(int seconds)
    {
        int min = seconds / 60;
        int sec = seconds % 60;

        return min.ToString("00") + ":" + sec.ToString("00");
    }
}
