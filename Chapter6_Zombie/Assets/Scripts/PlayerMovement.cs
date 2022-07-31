using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도


    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {
        // FixedUpdate 함수 내에서 Time.deltaTime은 자동으로 fixedDeltaTime으로 변환된다. 
        // 회전 실행.
        Rotate();
        // 움직임 실행.
        Move();

        /** 입력값에 따라 애니메이터의 Move 파라미터 값을 변경. 
         * SetFloat() 메소드는 애니메이터의 파라미터를 스트링으로 받아 해당 파라미터에 float 값을 전달함. */
        playerAnimator.SetFloat("Move", playerInput.move);        
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        /** 이동 거리를 벡터3 변수로 받아 Rigidbody 컴포넌트의 MovePosition() 메소드를 사용해 이동.
         * MovePosition은 현재 Rigidbody.position에서 매개변수로 받은 벡터3 좌표로 position을 이동시킨다.
         * transform.position은 오브젝트의 렌더링된 위치를 의미하고, Rigidbody.position은 강체를 가진 오브젝트의 물리적 위치를 의미한다.
         * 따라서 Rigidbody.position을 변경하여도, 물리 시뮬레이션이 끝난 후에 오브젝트 transform이 업데이트된다.
         * (그러므로 Rigidbody.position을 사용한 이동을 구현하면 Rigidbody.position과 transform.position이 달라질 수 있다.)
         * transform.position을 이용하여 오브젝트를 이동하면 이동하는 매 프레임 단위로 콜라이더들이 리지드바디 포지션을 연산하기 때문에 속도가 느려진다.
         * 물리 연산이 필요한 게임을 구축한다면 Rigidbody.position을 사용하는 것이 퍼포먼스 향상에 유리하다.
         * Rigidbody를 이용하는 방법은 다시 MovePosition() 메소드를 사용하는 방법과 직접 포지셔닝하는 방법이 있다.
         * MovePosition()을 이용하면 보간을 고려하기 때문에 자연스러운 움직임을 구현할 수 있다.
         * 그러므로 연속적인 이동을 구현해야 한다면 MovePosition()을 사용하는 것이 좋다. */
        // transform.forward는 현재 오브젝트가 바라보고 있는 정면을 월드 좌표 기준으로 반환한다.
        Vector3 moveDistance = transform.forward * moveSpeed * Time.deltaTime * playerInput.move;        
        /** MovePosition() 메소드는 매개변수로 상대위치가 아닌 전역위치를 받는다.
         * 그러므로 의도한 바와 같이 플레이어 오브젝트가 현재 위치로부터 이동한 거리를 받으려면,
         * 매개변수에 오브젝트의 현재 위치를 더하여 전달해야 한다. */
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate() {
        /** 이동과 마찬가지로 Rigidbody 컴포넌트의 rotation을 사용한다. 이유는 이동에서 설명했던 것과 같아 생략함. */
        // 상대적으로 회전할 수치를 계산함. 1초에 180도(오일러각)만큼 회전하는 것을 의도.
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        /** Rigidbody.rotation을 이용해 게임 오브젝트를 회전시킴. 
         * rotation은 쿼터니언이므로, 추가로 회전시키기 위해서는 *을 사용해야 함. */
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(new Vector3(0, turn, 0));
       
    }
}