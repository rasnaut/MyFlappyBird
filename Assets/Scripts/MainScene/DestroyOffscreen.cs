using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
  private float offset = 1.0f; // небольшой запас, чтобы убедиться, что объект полностью вышел за границы экрана
  private float objectWidth;

  private void Start()
  {
    objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
  }

  private void Update()
  {
    if (transform.position.x + objectWidth + offset < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
    {
      Destroy(gameObject);
    }
  }
}
