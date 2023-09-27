using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임 오버시 활성화할 텍스트 게임오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;// 최고기록을 표시할 텍스트 컴포넌트

    private float surviveTime; //생존 시간
    private bool isGameover; //게임 오버 상태

    void Start()
    {
        //생존 시간과 게임오버상태 초기화하기
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {

        //게임오버 상태가 아니라면
        if(!isGameover)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 시간 timeText에 표시하기
            timeText.text = "Time : " + surviveTime.ToString("F2");
        }
        //게임 오버라면
        else
        {
            //R키를 누른경우 리셋
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("SampleScene");
        }
    }

    //게임오버 상태로 만드는 메서드
    public void EndGame()
    {
        //게임오버 상태 전환
        isGameover = true;
        //게임오버 텍스트 활성화
        gameoverText.SetActive(true);

        //PlayerPrefs 를 활용하여 최고기록 저장/읽기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if(surviveTime>bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 recrodText 텍스트에 표시
        recordText.text = "Best Time : " + bestTime.ToString("F2");
    }
}
