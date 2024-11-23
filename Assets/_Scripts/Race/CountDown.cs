using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountDown : MonoBehaviour
{
    public static event UnityAction OnCountDownFinished;

    public void CountDownFinished()
    {
        OnCountDownFinished?.Invoke();
    }
}
