using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameHitPanel;
    public GameObject playButton;
    private BallInteraction rockInteraction;

    private void Start()
    {
        rockInteraction = FindObjectOfType<BallInteraction>();

        Time.timeScale = 0f;

        if (playButton != null)
        {
            Button playBtn = playButton.GetComponent<Button>();
            if (playBtn != null)
            {
                playBtn.onClick.AddListener(StartGame);
            }
        }
    }


    public void StartGame()
    {
        if (playButton != null)
        {
            playButton.SetActive(false);
        }

        Time.timeScale = 1f;

        if (gameHitPanel != null)
        {
            gameHitPanel.SetActive(true);
        }
    }

    public void EndGame()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            gameHitPanel.SetActive(false);
            rockInteraction.EndGame();
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
