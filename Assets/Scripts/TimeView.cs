using System.Collections;
using TMPro;
using UnityEngine;

public class TimeView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Timer _timer;

    private string _textNumber;
    private int _numberStopped = 1;
    private Coroutine _coroutine;
    private bool _�oroutineHasStarted = false;

    private void Start()
    {
        _textNumber = "0";
        _text.text = _textNumber;
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
        _textNumber = count.ToString("");
        _text.text = _textNumber;
    }
    private void ChangeTimer()
    {
        if (_�oroutineHasStarted && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _numberStopped = int.Parse(_textNumber.ToString());
            _�oroutineHasStarted = false;
        }
        else
        {
            _coroutine = StartCoroutine(Countdown(_numberStopped));
            _�oroutineHasStarted = true;
        }
    }
}
