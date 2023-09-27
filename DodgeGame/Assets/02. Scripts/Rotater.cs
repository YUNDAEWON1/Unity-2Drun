using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotationSpeed = 60f;
    private float rotationTime = 5f;
    private float time = 0;
    private bool rotatingClockwise = true; // 회전 방향

    void Update()
    {
        time += Time.deltaTime;

        // 현재 회전 방향에 따라 오브젝트를 회전
        if (rotatingClockwise)
        {
            transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
        }
        else
        {
            transform.Rotate(0f, Time.deltaTime * -rotationSpeed, 0f);
        }

        // 시간이 지난 경우 회전 방향 변경 및 time 초기화
        if (time >= rotationTime)
        {
            rotatingClockwise = !rotatingClockwise;
            time = 0;
        }
    }
}
