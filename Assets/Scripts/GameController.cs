using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public enum GameOverReason
  {
    Collision,
    OutOfBounds
  }
  // Start is called before the first frame update
  public static GameController instance;

  private GameOverReason reason = GameOverReason.Collision;
  private int score = 0;

  public void SetReason(GameOverReason _reason) {
    Debug.Log("GameController::SetReason(): reason = " + _reason);
    reason = _reason; 
  }
  public GameOverReason GetReason() {
    Debug.Log("GameController::GetReason(): reason = " + reason);
    return reason; 
  }
  public void AddScore(int points) { score += points; }
  public void ResetScore() { score = 0; }
  public void SetScore(int _score) { score = _score;}
  public int GetScore() { return score; }

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      Application.targetFrameRate = 60;
    }
    else
    {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);
  }

  void Update()
  {
    if (Input.GetKey(KeyCode.Escape))
    {
        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
        #else
          Application.Quit();
        #endif
    }
  }
}
