using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public void Action()
    {
        int number = 1000; // ��������� ��������

        while (number >= 0)
        {
            Debug.Log(number); // ������� ������� �������� � �������
            number -= 7; // �������� 7
        }
    }
}
