using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
  public float jumpForce = 5.0f; 
  public float horizontalSpeed = 4.0f; 
  private Rigidbody2D rb;
  public TextMeshProUGUI scoreText;
  private bool hasCollided = false;

  // Start is called before the first frame update
  void Start()
  {
    hasCollided = false;
    rb = GetComponent<Rigidbody2D>();
    if (GameController.instance != null)
      GameController.instance.ResetScore();
    else
      Debug.Log("PlayerController::Start(): GameController.instance is NULL!");
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.right * horizontalSpeed * Time.deltaTime);

    if (  Input.GetMouseButton(0)
      ||  Input.GetKey(KeyCode.Space)
      || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
    {
      Jump();
    }
  }
  private void Jump()
  {
    rb.velocity = Vector2.up * jumpForce;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    hasCollided = true;
    if (collision.gameObject.CompareTag("Obstacle"))
    {
      Debug.Log("Player hit an obstacle!");
      if (GameController.instance != null)
        GameController.instance.SetReason(GameController.GameOverReason.Collision);
      else
        Debug.Log("PlayerController::OnCollisionEnter2D(): GameController.instance is NULL!");

      SceneManager.LoadScene("GameOver");
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Coin"))
    {
      Debug.Log("Coin collected!");
      Destroy(other.gameObject);
      if (GameController.instance != null) {
        GameController.instance.AddScore(1);
        setScore(GameController.instance.GetScore());
      }
      else
        Debug.Log("PlayerController::OnTriggerEnter2D(): GameController.instance is NULL!");
    }
  }

  void OnBecameInvisible()
  {
    if(!hasCollided)
    {
      if (GameController.instance != null)
        GameController.instance.SetReason(GameController.GameOverReason.OutOfBounds);
      else
        Debug.Log("PlayerController::OnBecameInvisible(): GameController.instance is NULL!");
      SceneManager.LoadScene("GameOver");
    }
  }

  void setScore(int score)
  {
    scoreText.text = "Score: " + score;
  }
}
