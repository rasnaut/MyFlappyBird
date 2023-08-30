using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float backgroundSpeed = 0.3f;
    private float backgroundWidth; // Ширина фона
                                 // Start is called before the first frame update
    void Start()
    {
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.left * backgroundSpeed * Time.deltaTime);

      //if (transform.position.x <= -backgroundWidth)
      if (transform.position.x + backgroundWidth < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
      {
        // Перемещаем фон впереди другого
        Vector2 offset = new Vector2(backgroundWidth * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
      }
    }
}
