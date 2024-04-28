using System.Collections;
using TMPro;
using UnityEngine;

public class TimeView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Timer _timer;

    private int numberStopped = 1;
    private Coroutine coroutine = null;
    private bool CoroutineHasStarted = false;

    private void Start()
    {
        _text.text = "0";      
    }

    private void OnEnable()
    {
        _timer.OnClick += ChangeTimer;
    }

    private void OnDisable()
    {
        _timer.OnClick -= ChangeTimer;
    }                                                          

    private IEnumerator Countdown(int start, float delay = 0.5f)
    {
        var wait = new WaitForSeconds(delay);

        for (int i = start; i > 0; i++)
        {
            DisplayCountdown(i);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }

    private void ChangeTimer()
    {
        if (CoroutineHasStarted)
        {

            StopCoroutine(coroutine);
            numberStopped = int.Parse(_text.text.ToString());
            CoroutineHasStarted = false;
        }
        else
        {
            coroutine = StartCoroutine(Countdown(numberStopped));
            CoroutineHasStarted = true;
        }
    }
}
