using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour {
    public float speed = 10f; // 이동 속도

    private void Update() {
        // 현재 게임오버가 아닐 때만.
        if (!GameManager.instance.isGameover)
        {
            // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
            // 2d 게임이라 할 지라도 transform.position은 Vector3이다.
            //transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}