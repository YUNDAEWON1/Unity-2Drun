using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotationSpeed = 60f;
    private float rotationTime = 5f;
    private float time = 0;
    private bool rotatingClockwise = true; // ȸ�� ����

    void Update()
    {
        time += Time.deltaTime;

        // ���� ȸ�� ���⿡ ���� ������Ʈ�� ȸ��
        if (rotatingClockwise)
        {
            transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
        }
        else
        {
            transform.Rotate(0f, Time.deltaTime * -rotationSpeed, 0f);
        }

        // �ð��� ���� ��� ȸ�� ���� ���� �� time �ʱ�ȭ
        if (time >= rotationTime)
        {
            rotatingClockwise = !rotatingClockwise;
            time = 0;
        }
    }
}
