using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [Header("Settings")]
    public float swingSpeed = 200f; // �������� �������� ������
    public float angleA = 0f; // ���� ��������� ������� (����� A)
    public float angleB = 60f; // ���� �������� ������� (����� B)

    private bool isSwinging = false; // ���������� � ����� B
    private bool isReturning = false; // ���������� � ����� A
    private float currentAngle = 0f; // ������� ���� ��������

    private void Start()
    {
        // ������������� ��������� ����
        currentAngle = angleA;
        SetRotation(currentAngle);
    }

    private void Update()
    {
        // ���������� ��������� ������
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

        SetRotation(currentAngle); // ������������� ���� �������� ������
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
        // ������������ ������ �� ��� X
        transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}
