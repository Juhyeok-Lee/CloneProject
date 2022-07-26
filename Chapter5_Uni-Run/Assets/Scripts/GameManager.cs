using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour {
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    public bool isGameover = false; // 게임 오버 상태
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화 할 UI 게임 오브젝트

    private int score = 0; // 게임 점수

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake() {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;        // this는 스크립트 컴포넌트 자기 자신을 가리킴.
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Update() {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        // 게임 오버 상태에서 왼쪽 마우스 버튼을 클릭하면 if문을 실행.
        if (isGameover == true && Input.GetMouseButtonDown(0))
        {
            // LoadScene은 매개변수로 씬 이름을 받는다. SceneManager.GetActiveScene()은 현재 실행중인 씬을 씬 타입 오브젝트로 반환한다.
            // 즉, 아래 코드는 현재 활성화된 씬(실행중인 게임)의 이름을 받아 로드하는 함수이다.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore) {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            // 점수를 newScore만큼 증가.
            score += newScore;
            // scoreText의 텍스트 내용을 현재 스코어로 바꿔줌.
            scoreText.text = "Score: " + score;
        }
        
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead() {
        isGameover = true;
        // 게임 오버 UI를 활성화.
        gameoverUI.SetActive(true);
    }
}