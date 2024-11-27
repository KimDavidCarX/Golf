using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [Header("Settings")]
    public float swingSpeed = 200f; // Скорость вращения клюшки
    public float angleA = 0f; // Угол начальной позиции (точка A)
    public float angleB = 60f; // Угол конечной позиции (точка B)

    private bool isSwinging = false; // Стремление к точке B
    private bool isReturning = false; // Стремление к точке A
    private float currentAngle = 0f; // Текущий угол поворота

    private void Start()
    {
        // Устанавливаем начальный угол
        currentAngle = angleA;
        SetRotation(currentAngle);
    }

    private void Update()
    {
        // Управление движением клюшки
        if (isSwinging)
        {
            currentAngle += swingSpeed * Time.deltaTime;
            if (currentAngle > angleB) currentAngle = angleB;
        }
        else if (isReturning)
        {
            currentAngle -= swingSpeed * Time.deltaTime;
            if (currentAngle < angleA) currentAngle = angleA;
        }

        SetRotation(currentAngle); // Устанавливаем угол поворота клюшки
    }

    public void StartSwing()
    {
        isSwinging = true;
        isReturning = false;
    }

    public void StopSwing()
    {
        isSwinging = false;
        isReturning = true;
    }

    private void SetRotation(float angle)
    {
        // Поворачиваем клюшку по оси X
        transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}
