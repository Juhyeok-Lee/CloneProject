using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float speed = 8f;
   
    void Start()
    {
        // bulletRigidbody 변수에 자신의 리지드바디를 가져옴.
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞 방향 * 이동 속력.
        // transform.forward는 현재 게임 오브젝트의 앞 방향을 나타내는 벡터 변수.
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트를 파괴.
        Destroy(gameObject, 3f);        // Destroy(this)라고 쓰지 말 것. this는 현재 스크립트 자신을 가리킴.
    }

    private void OnTriggerEnter(Collider other) // 충돌한 다른 게임 오브젝트를 전달함.
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우. (플레이어와 탄알이 충돌했을 때.)
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();     // 충돌한 게임 오브젝트로부터 PlayerController 컴포넌트를 받아, 변수에 저장함.

            if (playerController != null)   // 충돌 오브젝트로부터 PlayerController 컴포넌트를 가져오는 데에 성공했다면.
            {
                playerController.Die();
            }
        }
    }
}
