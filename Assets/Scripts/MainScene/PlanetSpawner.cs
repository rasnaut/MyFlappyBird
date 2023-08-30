using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
  public GameObject[] planetPrefabs; // Массив префабов планет
  public float spawnInterval = 5.0f; // Интервал между спавном планет

  private float timer;

  private void Update()
  {
    timer += Time.deltaTime;

    if (timer >= spawnInterval)
    {
      SpawnPlanet();
      timer = 0;
    }
  }

  private void SpawnPlanet()
  {
    // Выбираем случайную планету из массива
    int randomIndex = Random.Range(0, planetPrefabs.Length);
    GameObject selectedPlanet = planetPrefabs[randomIndex];

    // Создаем планету на сцене
    Instantiate(selectedPlanet, GetSpawnPosition(), Quaternion.identity);
  }

  private Vector2 GetSpawnPosition()
  {
    float spawnX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    float spawnY = Random.Range(-6f, 6f); // Это примерные значения. Настройте их, чтобы планеты появлялись на нужной высоте.
    return new Vector2(spawnX, spawnY);
  }
}
