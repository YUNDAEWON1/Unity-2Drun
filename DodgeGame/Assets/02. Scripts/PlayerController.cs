using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // �÷��̾��� rigidbody
    public float speed = 8f;// �÷��̾� �ӵ�

     void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        #region ���� �� �̵����� �ڵ�
        /*�÷��̾� �̵����� Input �־��ֱ�

        //���� ����Ű �Է½� z�������� �ӵ���ŭ �̵�
        if(Input.GetKey(KeyCode.UpArrow)==true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        //�Ʒ��� ����Ű �Է½� -z�������� �ӵ���ŭ �̵�
        if(Input.GetKey(KeyCode.DownArrow)==true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        //������ ����Ű �Է½� x�������� �ӵ���ŭ �̵�
        if(Input.GetKey(KeyCode.RightArrow)==true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        //���� ����Ű �Է½� -x�������� �ӵ���ŭ �̵�
        if(Input.GetKey(KeyCode.LeftArrow)==true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/
        #endregion

        #region ���� �� �̵����� �ڵ�

        //������� �������� �Է°� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵��ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed,0,zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //������ٵ��� �ӵ��� newVelocity �Ҵ��ϱ�
        playerRigidbody.velocity = newVelocity;


        #endregion

       
    }
    //�÷��̾� ����� ó���� �Լ�
    public void Die()
    {
       this.gameObject.SetActive(false);

        //���� �����ϴ� GameManager Ÿ���� ������Ʈ ã�Ƽ� ����
        GameManager gameManager = FindObjectOfType<GameManager>();
        //������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();

    }
}
