using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ �Ѿ� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f;// �ִ� ���� �ֱ�

    private Transform target;//�߻��� ���
    private float spawnRate;//���� �ֱ�
    private float timeAfterSpawn;//�ֱ� ���� �������� ���� �ð�

    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //�Ѿ� ���� ������, Min,Max ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� Ÿ������ ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    //�Ѿ� �����ϱ�
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� �����ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn>=spawnRate)
        {
            //���� �ð� �ʱ�ȭ
            timeAfterSpawn = 0f;

            //bullet ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //������ bullet�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            //���� ���� ������ SpawnRateMin, SpawnRateMax ���̿��� ��������
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
