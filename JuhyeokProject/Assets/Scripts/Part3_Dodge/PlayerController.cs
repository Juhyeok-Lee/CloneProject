using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;   // �̵��� ����� �÷��̾��� ������ٵ� ������Ʈ. privaate ���� �����ڷ� �ν����� â���� ������ �� ���� ��.
    public float speed = 8f;            // �÷��̾��� �̵��ӷ�.
          
    public void Die()
    {
        // �ڽ��� ���ӿ�����Ʈ�� ��Ȱ��ȭ��.
        gameObject.SetActive(false);      // ��Ȱ��ȭ�� ���� ������Ʈ�� ������ ������� ������Ʈ�鵵 ����.


        // ���� �����ϴ� GameManager ������Ʈ�� ���� ������Ʈ�� ã�� ������.
        GameManager gameManager = FindObjectOfType<GameManager>();      // ���� �Ŵ����� ������Ʈ�̰� Find �Լ��� ������Ʈ�� ��ȯ�ϴµ�, �� GameManager ������ �ٷ� ������ �� �ִ°�?
        // GameManager ������Ʈ�� EndGame() �޼ҵ带 ����.
        gameManager.EndGame();
    }
           
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();  // �÷��̾� ������ٵ� ������ �ڱ��ڽ��� ������ٵ� GetComponent��.        
    }

    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����.
        float x_Input = Input.GetAxis("Horizontal"); // �����Է�.
        float z_Input = Input.GetAxis("Vertical");   // �����Է�.

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����Ͽ� ����.
        float x_spped = x_Input * speed;
        float z_speed = z_Input * speed;

        // Vector3 �ӵ��� (x_spped, 0, z_spped)�� ����.
        Vector3 newVelocity = new Vector3(x_spped, 0, z_speed);
        // �÷��̾� ������ٵ� ����Ű�� ���� ���� ������Ʈ�� ������ٵ� �ӵ��� newVelocity�� �Ҵ���.
        playerRigidbody.velocity = newVelocity;


        //if (Input.GetKey(KeyCode.UpArrow) == true)      // ���� ����Ű�� ������ ���� z�� �������� ���� ��.
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);    // �÷��̾� ������ٵ� z�� �������� ���ǵ常ŭ ���� ����.
        //}

        //if (Input.GetKey(KeyCode.DownArrow) == true)      // �Ʒ��� ����Ű�� ������ ���� -z�� �������� ���� ��.
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);    // �÷��̾� ������ٵ� -z�� �������� ���ǵ常ŭ ���� ����.
        //}

        //if (Input.GetKey(KeyCode.RightArrow) == true)      // ������ ����Ű�� ������ ���� x�� �������� ���� ��.
        //{
        //    playerRigidbody.AddForce(speed, 0f, 0f);    // �÷��̾� ������ٵ� x�� �������� ���ǵ常ŭ ���� ����.
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) == true)      // ���� ����Ű�� ������ ���� -x�� �������� ���� ��.
        //{
        //    playerRigidbody.AddForce(-speed, 0f, 0f);    // �÷��̾� ������ٵ� -x�� �������� ���ǵ常ŭ ���� ����.
        //}

    }
}
