using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    /*public GameObject obstaclePrefab; // Префаб препятствия
    public float spawnInterval = 2.0f; // Интервал между спавном препятствий
    private float timer;*/

    [System.Serializable]
    public class Spawnable
    {
        public GameObject prefab; // Префаб объекта
        public float spawnInterval; // Интервал между спавном объектов
        public float minY; // Минимальная высота спавна
        public float maxY; // Максимальная высота спавна

        [HideInInspector]
        public float timer; // Таймер для каждого объекта
    }

    public List<Spawnable> spawnables;

    private void Update()
    {
        foreach (var spawnable in spawnables)
        {
          spawnable.timer += Time.deltaTime;

          if (spawnable.timer >= spawnable.spawnInterval)
          {
            Spawn(spawnable);
            spawnable.timer = 0;
          }
        }
    }

    private void Spawn(Spawnable spawnable)
    {
      Vector2 spawnPosition = GetSpawnPosition(spawnable);
      Instantiate(spawnable.prefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 GetSpawnPosition(Spawnable spawnable)
    {
        float spawnX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width+15, 0, 0)).x;
        float spawnY = Random.Range(spawnable.minY, spawnable.maxY); // Это примерные значения. Настройте их, чтобы препятствия появлялись на нужной высоте.
        return new Vector2(spawnX, spawnY);
    }

}
