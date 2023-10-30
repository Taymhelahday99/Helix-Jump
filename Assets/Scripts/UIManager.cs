using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

   public TextMeshProUGUI txtScore;
   public TextMeshProUGUI txtBest;
   public GameObject titleScreen;

    void Update()
    {
        txtBest.text = "Best: " + GameManager.singleton.best;
        txtScore.text = "Score: " + GameManager.singleton.score;
    }
}
