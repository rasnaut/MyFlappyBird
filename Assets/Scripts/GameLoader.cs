using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
  // Ссылки на менеджеров
  public GameObject game_manager; // Game Base Manager

  // Метод пробуждения объекта (перед стартом игры)
  void Awake()
  {
    // Инициализация игровой базы
    if (GameController.instance == null)
    {
      Instantiate(game_manager);
    }
  }
}