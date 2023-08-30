using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
  public GameObject collisionGameOverConvas; 
  public GameObject outOfBoundsGameOverConvas;
  public SceneFader sceneFader1, sceneFader2;
  public ScoreSetter scoreSetter;

  private SceneFader sceneFaderActive;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      sceneFaderActive.FadeTo("MainScene");
    }
  }

  void Awake()
  {
    Debug.Log("!!!HandleGameOver!!!");
    if(GameController.instance != null)
    {
      scoreSetter.score = GameController.instance.GetScore();
      if (GameController.instance.GetReason() == GameController.GameOverReason.Collision)
      {
        Debug.Log("GameOverScene::Awake() Collision");
        collisionGameOverConvas.SetActive(true);
        outOfBoundsGameOverConvas.SetActive(false);
        sceneFaderActive = sceneFader1;
      }
      else if (GameController.instance.GetReason() == GameController.GameOverReason.OutOfBounds)
      {
        Debug.Log("GameOverScene::Awake() OutOfBounds");
        collisionGameOverConvas.SetActive(false);
        outOfBoundsGameOverConvas.SetActive(true);
        sceneFaderActive = sceneFader2;
      }
    }
    else
      Debug.Log("GameOverScene::Awake(): GameController.instance is NULL!");
  }
}
