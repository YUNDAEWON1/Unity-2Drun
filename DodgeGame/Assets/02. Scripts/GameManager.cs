using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���� ������ Ȱ��ȭ�� �ؽ�Ʈ ���ӿ�����Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;// �ְ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; //���� �ð�
    private bool isGameover; //���� ���� ����

    void Start()
    {
        //���� �ð��� ���ӿ������� �ʱ�ȭ�ϱ�
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {

        //���ӿ��� ���°� �ƴ϶��
        if(!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ �ð� timeText�� ǥ���ϱ�
            timeText.text = "Time : " + surviveTime.ToString("F2");
        }
        //���� �������
        else
        {
            //RŰ�� ������� ����
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("SampleScene");
        }
    }

    //���ӿ��� ���·� ����� �޼���
    public void EndGame()
    {
        //���ӿ��� ���� ��ȯ
        isGameover = true;
        //���ӿ��� �ؽ�Ʈ Ȱ��ȭ
        gameoverText.SetActive(true);

        //PlayerPrefs �� Ȱ���Ͽ� �ְ��� ����/�б�
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if(surviveTime>bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� recrodText �ؽ�Ʈ�� ǥ��
        recordText.text = "Best Time : " + bestTime.ToString("F2");
    }
}
