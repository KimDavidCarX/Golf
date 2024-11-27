using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool hasBeenHit = false;
    public bool canEndGame = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasBeenHit = true;
            canEndGame = false;
        }

        Ball otherRock = collision.gameObject.GetComponent<Ball>();
        if (otherRock != null)
        {

            if (!hasBeenHit || !otherRock.hasBeenHit)
            {

                FindObjectOfType<LevelController>().EndGame();
            }
            else
            {

                if (canEndGame || otherRock.canEndGame)
                {

                    FindObjectOfType<LevelController>().EndGame();
                }
            }
        }
    }

    public void HitBall()
    {

        canEndGame = false;
        hasBeenHit = true;
    }

}
