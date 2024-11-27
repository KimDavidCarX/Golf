using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool hasBeenHit = false; // Мячик был пнут
    public bool canEndGame = true;  // Способность завершить игру (по умолчанию включена)

    private void OnCollisionEnter(Collision collision)
    {
        // Проверка столкновения с объектом с тегом "Club" (клюшка)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Если мячик не был пнут, отключаем возможность завершить игру
            hasBeenHit = true;
            canEndGame = false;
        }

        // Проверка столкновения с другим мячиком (с тегом "Ball")
        Ball otherRock = collision.gameObject.GetComponent<Ball>();
        if (otherRock != null)
        {
            // Если один из мячиков не был пнут, завершаем игру
            if (!hasBeenHit || !otherRock.hasBeenHit)
            {
                // Завершаем игру, если мячики коснулись друг друга и хотя бы один не был пнут
                FindObjectOfType<LevelController>().EndGame();
            }
            else
            {
                // Если оба мячика были пнуты, проверяем, можно ли завершить игру
                if (canEndGame || otherRock.canEndGame)
                {
                    // Завершаем игру
                    FindObjectOfType<LevelController>().EndGame();
                }
            }
        }
    }

    // Метод для "пинания" мячика (когда матыга касается камня)
    public void HitBall()
    {
        // Если мячик был пнут, отключаем возможность завершить игру
        canEndGame = false;
        hasBeenHit = true; // Мячик теперь считается пнутым
    }

}
