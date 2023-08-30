using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
  public Image img;
  public AnimationCurve curve;

  void Start()
  {
    StartCoroutine(FadeIn());
  }

  public void FadeTo(string scene)
  {
    StartCoroutine(FadeOut(scene));
  }

  IEnumerator FadeIn()
  {
    float t = 1f;

    while (t > -5f)
    {
      t -= Time.deltaTime;
      float a = curve.Evaluate(t);
      Debug.Log("FadeIn a = " + a);
      img.color = new Color(0f, 0f, 0f, a);
      yield return 0;
    }
  }

  IEnumerator FadeOut(string scene)
  {
    float t = 0f;

    while (t < 1f)
    {
      t += Time.deltaTime;
      float a = curve.Evaluate(t);
      Debug.Log("FadeOut a = " + a);
      img.color = new Color(0f, 0f, 0f, a);
      yield return 0;
    }

    SceneManager.LoadScene(scene);
  }
}
