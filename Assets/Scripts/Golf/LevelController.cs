using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    public GameObject gameOverPanel;  // Панель завершения игры
    public GameObject gameHitPanel;   // Панель при попадании матыги по камню
    public GameObject playButton;     // Кнопка для старта игры
    private BallInteraction rockInteraction;  // Ссылка на скрипт взаимодействия с камнями

    private void Start()
    {
        rockInteraction = FindObjectOfType<BallInteraction>();  // Получаем ссылку на скрипт BallInteraction

        // Изначально ставим Time.timeScale в 0 (пауза)
        Time.timeScale = 0f;

        // Привязываем кнопку Play
        if (playButton != null)
        {
            Button playBtn = playButton.GetComponent<Button>();
            if (playBtn != null)
            {
                playBtn.onClick.AddListener(StartGame);  // При нажатии на кнопку Play запускаем игру
            }
        }
    }

    // Метод для старта игры
    public void StartGame()
    {
        // Скрываем кнопку Play
        if (playButton != null)
        {
            playButton.SetActive(false);
        }

        // Снимаем паузу, увеличиваем timeScale
        Time.timeScale = 1f;

        // Можно, например, сразу показать панель попаданий (если нужно)
        if (gameHitPanel != null)
        {
            gameHitPanel.SetActive(true);
        }
    }

    // Метод завершения игры
    public void EndGame()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // Показываем панель завершения игры
            gameHitPanel.SetActive(false);  // Скрываем панель при попадании
            rockInteraction.EndGame();      // Завершаем взаимодействие с камнями
        }

        Time.timeScale = 0f;  // Останавливаем игру
    }

    // Метод для перезагрузки игры
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Возвращаем игру в нормальный режим

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);  // Скрываем панель завершения игры
        }

        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
