using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 플레이어의 rigidbody
    public float speed = 8f;// 플레이어 속도

     void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        #region 변경 전 이동관련 코드
        /*플레이어 이동관련 Input 넣어주기

        //위쪽 방향키 입력시 z방향으로 속도만큼 이동
        if(Input.GetKey(KeyCode.UpArrow)==true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        //아래쪽 방향키 입력시 -z방향으로 속도만큼 이동
        if(Input.GetKey(KeyCode.DownArrow)==true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        //오른쪽 방향키 입력시 x방향으로 속도만큼 이동
        if(Input.GetKey(KeyCode.RightArrow)==true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        //왼쪽 방향키 입력시 -x방향으로 속도만큼 이동
        if(Input.GetKey(KeyCode.LeftArrow)==true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/
        #endregion

        #region 변경 후 이동관련 코드

        //수평축과 수직축의 입력값 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed,0,zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //리지드바디의 속도에 newVelocity 할당하기
        playerRigidbody.velocity = newVelocity;


        #endregion

       
    }
    //플레이어 사망시 처리할 함수
    public void Die()
    {
       this.gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트 찾아서 참조
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();

    }
}
