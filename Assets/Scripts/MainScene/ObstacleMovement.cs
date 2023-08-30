using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
   public float speed = -2.5f;
   public bool isRotate = false;
   private float rotationSpeed;
  // Start is called before the first frame update
  void Start()
  {
    if(isRotate)
      rotationSpeed = Random.Range(-100f, 100f);
  }

    // Update is called once per frame
  void Update()
  {
    Vector2 position = transform.position;
    position.x -= speed * Time.deltaTime;
    transform.position = position;

    if(isRotate)
      transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
  }
}
