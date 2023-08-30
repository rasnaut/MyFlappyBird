using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
  public TextMeshProUGUI scoreText1;
  public TextMeshProUGUI scoreText2;
  public int score;
    // Start is called before the first frame update
    void Start()
    {
      scoreText1.text = "Your score: " + score;
      scoreText2.text = "Your score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
