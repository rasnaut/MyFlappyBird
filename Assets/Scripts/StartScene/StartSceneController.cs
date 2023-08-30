using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour
{
  public SceneFader sceneFader;
    // Start is called before the first frame update
  void Start()
  {
     Application.targetFrameRate = 60;
  }

    // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      sceneFader = FindObjectOfType<SceneFader>();
      sceneFader.FadeTo("MainScene");
    }
  }
}
