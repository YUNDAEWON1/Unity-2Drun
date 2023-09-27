using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //총알 속도
    private Rigidbody bulletRigidbody; //리지드바디
    
    

    void Start()
    {
        //Bullet의 Rigidbody 컴포넌트 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //Bullet 속도 설정
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤에 삭제되게하기
        Destroy(gameObject, 3f);
    }


 s

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 게임오브젝트가 Player라면
        if (other.tag == "Player")
        {
            //충돌한 게임오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //PlayerController 컴포넌트 가져오기를 성공했다면 Die() 메서드 실행
            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
