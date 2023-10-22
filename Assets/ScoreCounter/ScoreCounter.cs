using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
   [SerializeField] private ScoreObject score;
   [SerializeField] private TMP_Text text;
   [SerializeField] private string PREFIX = "";
   private const string FORMAT = "00000000";

   private void OnEnable() {
      score.OnScoreChange += OnScoreChange;
      text.text = FORMAT;
   }

   private void OnDisable() {
      score.OnScoreChange -= OnScoreChange;
   }

   private void OnScoreChange(int newScore) {
      text.text = PREFIX + newScore.ToString(FORMAT);
   }
}
