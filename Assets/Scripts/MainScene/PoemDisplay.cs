using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoemDisplay : MonoBehaviour
{
  public TextMeshProUGUI textUI;
  private string[] lines; 

  void Start()
  {
    TextAsset textAsset = Resources.Load<TextAsset>("poem");
    if (textAsset != null)
    {
      lines = textAsset.text.Split('\n');
      StartCoroutine(DisplayPoem());
    }
    else
      Debug.LogError("Load file ERROR!");
  }

  IEnumerator DisplayPoem()
  {
    foreach (string line in lines)
    {
      textUI.text = line;
      yield return StartCoroutine(FadeTextToFullAlpha(1f, textUI));
      yield return new WaitForSeconds(2); // Пауза на 2 секунды
      yield return StartCoroutine(FadeTextToZeroAlpha(1f, textUI));
    }
  }

  public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
  {
    i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    while (i.color.a < 1.0f)
    {
      i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
      yield return null;
    }
  }

  public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
  {
    i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
    while (i.color.a > 0.0f)
    {
      i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
      yield return null;
    }
  }
}
