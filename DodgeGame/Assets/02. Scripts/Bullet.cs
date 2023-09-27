using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //�Ѿ� �ӵ�
    private Rigidbody bulletRigidbody; //������ٵ�
    
    

    void Start()
    {
        //Bullet�� Rigidbody ������Ʈ �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //Bullet �ӵ� ����
        bulletRigidbody.velocity = transform.forward * speed;

        //3�� �ڿ� �����ǰ��ϱ�
        Destroy(gameObject, 3f);
    }


 s

    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ���ӿ�����Ʈ�� Player���
        if (other.tag == "Player")
        {
            //�浹�� ���ӿ�����Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            //PlayerController ������Ʈ �������⸦ �����ߴٸ� Die() �޼��� ����
            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
