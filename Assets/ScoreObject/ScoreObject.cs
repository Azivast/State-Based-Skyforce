using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Score", menuName = "ScoreObject")]
public class ScoreObject : ScriptableObject
{
    public int Score;
    public UnityAction<int> OnScoreChange = delegate{};
    public UnityAction<int> OnScoreChangeDelta = delegate{};

    public void Reset() {
        Score = 0;
    }

    public void IncreaseScore(int amount) {
        Score += amount;
        OnScoreChange(Score);
        OnScoreChangeDelta(amount);
    }
}
