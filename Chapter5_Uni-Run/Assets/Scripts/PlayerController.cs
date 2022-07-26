using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
        // 게임 오브젝트로부터 사용할 컴포넌트를 가져와 컴포넌트 변수에 할당.
        // private이므로 인스펙터에선 접근할 수 없음.
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
   }

   private void Update() {        
        if (isDead)
        {
        // 사망하면 더 이상 처리를 진행하지 않고 업데이트 함수를 리턴.
            return;
        }

        // 마우스 왼쪽 버튼을 눌렀고, 최대 점프 횟수(2)에 도달하지 않았다면,
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // 점프 횟수를 증가시킨다.
            jumpCount++;
            // 점프 직전 순간 속도를 제로(0,0)로 변경한다.
            playerRigidbody.velocity = Vector2.zero; // 영벡터 변수.
            // 플레이어 오브젝트 리지드바디에 위쪽으로 점프 힘 더함. (AddForce)
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // 오디오 소스 컴포넌트가 기본 할당된 점프 오디오 클립을 재생함.
            playerAudio.Play();
        }
        // 마우스 버튼에서 손을 뗐을 때, 속도의 y값이 양수라면. (위로 상승 중)
        // 현재 속도를 절반으로 줄인다. (버튼 클릭 길이에 따라 점프 높이가 달라짐)
        // GetMoiseButton의 파라미터는 버튼을 가리킨다. 0: 왼쪽, 1: 오른쪽.
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // Rigidbody 컴포넌트의 velocity는 벡터2이므로 스칼라곱이 가능.
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        // 애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신한다.
        // isGrounded가 참이면 Run으로 전이, 아니면 Jump로 전이되도록.
        // SetBool은 첫 매개변수로 애니메이터의 파라미터 명을 받는다.
        animator.SetBool("Grounded", isGrounded);
   }

   private void Die() {
        // 애니메이터의 Die 트리거 파라미터를 셋.
        // 오브젝트가 사망 애니메이션을 재생할 수 있음. (반복x)
        animator.SetTrigger("Die");

        // 오디오 소스에 할당된 오디오 클립을 deathCLIP으로 바꿔줌.
        // 기본은 Jump로 할당되어 있음.
        playerAudio.clip = deathClip;
        // 오디오 재생.
        playerAudio.Play();

        // 속도를 제로(0, 0)로 변경.
        playerRigidbody.velocity = Vector2.zero;
        // 사망 상태(isDead)를 참으로 변경.
        isDead = true;
   }

   private void OnTriggerEnter2D(Collider2D other) {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        // 그 장애물이 Dead 태그를 갖고 있는지 검사.
        // 사망을 두 번 하면 안 되니까, isDead가 거짓일 때만 작동.
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
        // 트리거가 아닌 콜라이더와 닿았는데 노멀벡터가 위를 보고 있을 때.
        // 노멀벡터는 표면과 수직인 벡터. y값이 |1|에 가까울 수록 수직.
        // 노멀벡터의 y가 완전히 1은 아니여도 절벽만 아니면 괜찮음.
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
        
   }

   private void OnCollisionExit2D(Collision2D collision) {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
   }
}