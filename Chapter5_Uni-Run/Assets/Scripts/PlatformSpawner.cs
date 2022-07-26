using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class PlatformSpawner : MonoBehaviour {
    public GameObject platformPrefab; // 생성할 발판의 원본 프리팹
    public int count = 3; // 생성할 발판의 개수

    public float timeBetSpawnMin = 1.25f; // 다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; // 다음 배치까지의 시간 간격 최댓값
    private float timeBetSpawn; // 다음 배치까지의 시간 간격

    public float yMin = -3.5f; // 배치할 위치의 최소 y값
    public float yMax = 1.5f; // 배치할 위치의 최대 y값
    private float xPos = 20f; // 배치할 위치의 x 값

    private GameObject[] platforms; // 미리 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    private Vector2 poolPosition = new Vector2(0, -25); // 초반에 생성된 발판들을 화면 밖에 숨겨둘 위치
    private float lastSpawnTime; // 마지막 배치 시점


    void Start() {
        // count 크기만큼의 공간을 갖는 새로운 발판 오브젝트의 배열을 생성.
        platforms = new GameObject[count];

        // count만큼 루프하며 발판 오브젝트를 생성함.
        for(int i = 0; i < count; i++)
        {
            // platformPrefab을 원본으로 하여 새 발판을 poolPosition에 복제 생성. (원본을 받아 클론을 생성하는 instantiate 함수 사용)
            // 생성된 발판을 배열의 각 원소에 할당.
            // instantiate 함수는 매개변수로 원본, 생성 위치, 생성 각도를 받는다. 각도는 쿼터니언임에 주의.
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);  // Quaternion.identity는 회전이 없음을 뜻함.
        }

        // 마지막 배치 시점 초기화.
        lastSpawnTime = 0f;
        // 다음 번 배치까지의 시간 간격을 초기화.
        timeBetSpawn = 0f;
    }

    void Update() {
        // 순서를 돌아가며 주기적으로 발판을 배치

        // 게임 오버 상태에선 더 이상 발판 스포너가 돌아가지 않음.
        if (GameManager.instance.isGameover)
        {
            return; // 여기서 함수가 종료.
        }

        // 마지막 배치 시점으로부터 timeBetSpawn 이상 시간이 흘렀다면 새 발판을 생성.
        if (Time.time > lastSpawnTime + timeBetSpawn)
        {
            // 마지막 배치 시점을 현재 시점으로 갱신해줌.
            lastSpawnTime = Time.time;

            // 다음 배치까지의 시간을 랜덤하게 설정.
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            // 오브젝트를 배치할 위치의 y값을 랜덤으로 설정.
            float yPos = Random.Range(yMin, yMax);

            // 배치할 오브젝트를 껐다 켜서 장애물을 랜덤으로 생성함. 그래야 새로 배치되는 오브젝트들이 랜덤한 장애물을 갖게 됨.
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            // 현재 순번의 발판을 화면 오른쪽에 배치함. yPos는 위에서 랜덤으로 설정됨.
            // transform.position은 벡터3지만 벡터2에서 벡터3로의 변환은 암시적으로 가능하다. 그 역은 성립하지 않는다.
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            // 현재 순번을 1 늘림.
            currentIndex++;

            // 마지막 순번에 도달했다면 순번을 0으로 리셋함.
            if (currentIndex >= count) 
            {
                currentIndex = 0;
            }            
        }
    }
}