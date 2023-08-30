using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // Ссылка на Transform игрока
    public float offsetX = 2.0f; // Смещение камеры относительно игрока по горизонтали

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Если игрок не задан, не делать ничего
        if (!playerTransform) return;

        // Получить текущую позицию камеры
        Vector3 cameraPosition = transform.position;

        // Установить позицию камеры так, чтобы она следовала за игроком по горизонтали с заданным смещением
        cameraPosition.x = playerTransform.position.x + offsetX;

        // Применить новую позицию к камере
        transform.position = cameraPosition;
    }
}
