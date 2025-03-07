using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBank : MonoBehaviour
{
    public static UnityEvent OnThrowFinished = new UnityEvent();
    public static UnityEvent OnGameFinished = new UnityEvent();
    public static UnityEvent<int> OnScoreCalculated = new UnityEvent<int>();
}
