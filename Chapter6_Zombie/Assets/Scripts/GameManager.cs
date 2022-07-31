using UnityEngine;

// 점수와 게임 오버 여부를 관리하는 게임 매니저
public class GameManager : MonoBehaviour {
    // 싱글톤 접근용 프로퍼티. 외부에서 GamaManager의 인스턴스에 접근할 때에는 GameManager.instance라는 이름으로 접근함. 실제 생성된 m_instance를 반환.
    // 이하 프로퍼티에 대한 코드는 GameManager 오브젝트가 생성됐을 떄 실행되는 게 아니라, 외부에서 instance라는 이름을 접근했을 때 실행되는 것.
    // 오브젝트가 생성됐을 때에는 Awake()부터 실행됨.
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 실제로 할당될 static 변수. private이므로 외부에선 접근할 수 없음. 프로퍼티를 통한 접근만 가능.

    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    private void Awake() {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴. this는 스크립트를 가리키는 것이므로 this가 아닌 gameObject를 파괴해야 함.
            Destroy(gameObject);            
        }
    }

    private void Start() {
        // 플레이어 캐릭터의 사망 이벤트 발생시 게임 오버
        // PlayerHealth 스크립트를 찾음. 해당 메소드로 스크립트가 추가된 오브젝트로 바로 접근 가능.
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }

    // 점수를 추가하고 UI 갱신
    public void AddScore(int newScore) {
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!isGameover)
        {
            // 점수 추가
            score += newScore;
            // 점수 UI 텍스트 갱신
            UIManager.instance.UpdateScoreText(score);
        }
    }

    // 게임 오버 처리
    public void EndGame() {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
        UIManager.instance.SetActiveGameoverUI(true);
    }
}