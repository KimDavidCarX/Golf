using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public void Action()
    {
        int number = 1000; // Начальное значение

        while (number >= 0)
        {
            Debug.Log(number); // Выводим текущее значение в консоль
            number -= 7; // Отнимаем 7
        }
    }
}
