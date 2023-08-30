using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    public float magnetSpeed = 5f; // Скорость, с которой монетка будет двигаться к игроку
    public float magnetRange = 2f; // Расстояние, на котором монетка начнет двигаться к игроку

    private Transform playerTransform;
  // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= magnetRange)
        {
          transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, magnetSpeed * Time.deltaTime);
        }
    }
}
