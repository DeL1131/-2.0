using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnClick;

    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
