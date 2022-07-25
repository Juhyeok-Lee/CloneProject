using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   // UI 관련 라이브러리.
using UnityEngine.SceneManagement;      // 씬 관리 관련 라이브러리.
// using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;                   // 게임오버 시 활성화될 텍스트 '오브젝트'.
    public Text timeText;
    //  public TextMeshProUGUI timeText;               // 생존 시간을 표시할 텍스트 '컴포넌트'. Text(Legacy)가 아닌 TMP는 인스펙터에서 Text에 직접 드래그 앤 드롭할 수 없다.
                                                                         // TMP를 사용하고 싶다면 using TMPro; 후, 변수를 Text가 아닌 TextMeshProUGUI로 선언하고 인스펙터창에서 접근할 것.
    public Text recordText;                                    // 최고 기록을 표시할 텍스트 '컴포넌트'.

    private float survivalTime;         // 생존 시간.
    private bool isGameover;            // 게임오버 상태.

    // 현재 게임을 게임오버 상태로 변경하는 메소드.
    public void EndGame()       // GameController 클래스에서 접근 가능하도록 public으로 설정.
    {
        // isGameover를 참으로 바꿈.
        isGameover = true;
        // 게임오버 텍스트 오브젝트를 활성화.
        gameoverText.SetActive(true);

        // BestTime 키로 저장된 이전까지의 최고 기록을 가져오기. PlayerPrefs를 사용하면 어떤 수치를 컴퓨터에 저장하고 프로그램을 재실행한 뒤에도 불러올 수 있다.
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면.
        if (survivalTime > bestTime)
        {
            // 최고 기록을 현재 생존 시간으로 치환.
            bestTime = survivalTime;
            // 변경된 최고 기록을 BestTime 키로 저장.
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 컴포넌트를 이용하여 표시. 새로운 게임에서 최고 기록을 갱신하지 못했다면, 기존 bestTime이 출력될 것.
        recordText.text = "Best Time: " + (int)bestTime;
    }

    void Start()
    {
        // 변수를 초기화.
        survivalTime = 0f;
        isGameover = false;
    }
        
    void Update()
    {
        // 게임오버가 아닌 동안만.
        if (!isGameover)
        {
            // 생존 시간 갱신.
            survivalTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용하여 표시.
            timeText.text = "Time: " + (int)survivalTime;
        }
        else
        {
            // 게임오버 상태에서 R키를 누른 경우. (재시작)
            if (Input.GetKeyDown(KeyCode.R))       // GetKeyDown은 키입력을 감지하여 불값을 반환함.
            {
                // Dodge 씬을 재 로드. LoadScene을 사용할 때, 로드될 씬은 빌드 목록에 있어야 한다. 씬 이름이 아닌 빌드 목록의 빌드 순번을 이용해 씬을 호출할 수도 있다.
                SceneManager.LoadScene("Part3_Dodge_07_23");
            }
        }
        
    }       
}
