using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    public int score = 0;
    private int highScore = 0;
    public float minHitForce = 200f; // Минимальная сила удара
    public float maxHitForce = 500f; // Максимальная сила удара
    public float forceChangeInterval = 1f; // Интервал в секундах для изменения силы
    private float currentHitForce; // Текущая сила удара

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScore();

        currentHitForce = minHitForce; // Устанавливаем начальную силу удара
        InvokeRepeating("ChangeHitForce", 0f, forceChangeInterval); // Каждую секунду меняем силу удара
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            score++;
            UpdateScore();

            Rigidbody rockRb = collision.gameObject.GetComponent<Rigidbody>();
            if (rockRb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                rockRb.AddForce(direction * currentHitForce, ForceMode.Impulse); // Применяем текущую силу удара
            }
        }
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void UpdateHighScore()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void EndGame()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateHighScore();
    }

    // Метод для изменения силы удара каждую секунду
    private void ChangeHitForce()
    {
        // Меняем силу удара случайным образом в пределах от minHitForce до maxHitForce
        currentHitForce = Random.Range(minHitForce, maxHitForce);
    }

}
