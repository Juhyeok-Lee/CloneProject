using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour {
    private float width; // 배경의 가로 길이

    private void Awake() {
        // 가로 길이를 측정하는 처리
        // 박스콜라이더2D 컴포넌트를 먼저 변수로 초기화.
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        // 박스콜라이더 컴포넌트의 사이즈의 x값을 받아 width에 대입.
        width = backgroundCollider.size.x;
    }

    private void Update() {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 리셋
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition() {
        Vector2 offset = new Vector2(2f * width, 0);
        // transform.position은 Vector3이므로, offset과 연산하려면 명시적으로 형변환을 해야 함.
        transform.position = (Vector2)transform.position + offset;
    }
}