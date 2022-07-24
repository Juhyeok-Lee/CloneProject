using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;   // 이동에 사용할 플레이어의 리지드바디 컴포넌트. privaate 접근 한정자로 인스펙터 창에서 접근할 수 없게 됨.
    public float speed = 8f;            // 플레이어의 이동속력.
          
    public void Die()
    {
        // 자신의 게임오브젝트를 비활성화함.
        gameObject.SetActive(false);      // 비활성화된 게임 오브젝트는 씬에서 사라지고 컴포넌트들도 멈춤.


        // 씬에 존재하는 GameManager 컴포넌트를 가진 오브젝트를 찾아 가져옴.
        GameManager gameManager = FindObjectOfType<GameManager>();      // 게임 매니저는 컴포넌트이고 Find 함수는 오브젝트를 반환하는데, 왜 GameManager 변수에 바로 대입할 수 있는가?
        // GameManager 컴포넌트의 EndGame() 메소드를 실행.
        gameManager.EndGame();
    }
           
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();  // 플레이어 리지드바디 변수에 자기자신의 리지드바디를 GetComponent함.        
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장.
        float x_Input = Input.GetAxis("Horizontal"); // 수평입력.
        float z_Input = Input.GetAxis("Vertical");   // 수직입력.

        // 실제 이동 속도를 입력값과 이동 속력을 사용하여 결정.
        float x_spped = x_Input * speed;
        float z_speed = z_Input * speed;

        // Vector3 속도를 (x_spped, 0, z_spped)로 생성.
        Vector3 newVelocity = new Vector3(x_spped, 0, z_speed);
        // 플레이어 리지드바디가 가리키는 현재 게임 오브젝트의 리지드바디 속도에 newVelocity를 할당함.
        playerRigidbody.velocity = newVelocity;


        //if (Input.GetKey(KeyCode.UpArrow) == true)      // 위쪽 방향키를 눌렀을 때는 z축 방향으로 힘을 줌.
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);    // 플레이어 리지드바디에 z축 방향으로 스피드만큼 힘을 가함.
        //}

        //if (Input.GetKey(KeyCode.DownArrow) == true)      // 아래쪽 방향키를 눌렀을 때는 -z축 방향으로 힘을 줌.
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);    // 플레이어 리지드바디에 -z축 방향으로 스피드만큼 힘을 가함.
        //}

        //if (Input.GetKey(KeyCode.RightArrow) == true)      // 오른쪽 방향키를 눌렀을 때는 x축 방향으로 힘을 줌.
        //{
        //    playerRigidbody.AddForce(speed, 0f, 0f);    // 플레이어 리지드바디에 x축 방향으로 스피드만큼 힘을 가함.
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) == true)      // 왼쪽 방향키를 눌렀을 때는 -x축 방향으로 힘을 줌.
        //{
        //    playerRigidbody.AddForce(-speed, 0f, 0f);    // 플레이어 리지드바디에 -x축 방향으로 스피드만큼 힘을 가함.
        //}

    }
}
