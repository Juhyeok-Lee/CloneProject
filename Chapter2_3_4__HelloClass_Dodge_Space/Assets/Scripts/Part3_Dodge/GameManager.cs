using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   // UI ���� ���̺귯��.
using UnityEngine.SceneManagement;      // �� ���� ���� ���̺귯��.
// using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;                   // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ '������Ʈ'.
    public Text timeText;
    //  public TextMeshProUGUI timeText;               // ���� �ð��� ǥ���� �ؽ�Ʈ '������Ʈ'. Text(Legacy)�� �ƴ� TMP�� �ν����Ϳ��� Text�� ���� �巡�� �� ����� �� ����.
                                                                         // TMP�� ����ϰ� �ʹٸ� using TMPro; ��, ������ Text�� �ƴ� TextMeshProUGUI�� �����ϰ� �ν�����â���� ������ ��.
    public Text recordText;                                    // �ְ� ����� ǥ���� �ؽ�Ʈ '������Ʈ'.

    private float survivalTime;         // ���� �ð�.
    private bool isGameover;            // ���ӿ��� ����.

    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼ҵ�.
    public void EndGame()       // GameController Ŭ�������� ���� �����ϵ��� public���� ����.
    {
        // isGameover�� ������ �ٲ�.
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ������Ʈ�� Ȱ��ȭ.
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ����� ��������. PlayerPrefs�� ����ϸ� � ��ġ�� ��ǻ�Ϳ� �����ϰ� ���α׷��� ������� �ڿ��� �ҷ��� �� �ִ�.
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�.
        if (survivalTime > bestTime)
        {
            // �ְ� ����� ���� ���� �ð����� ġȯ.
            bestTime = survivalTime;
            // ����� �ְ� ����� BestTime Ű�� ����.
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText ������Ʈ�� �̿��Ͽ� ǥ��. ���ο� ���ӿ��� �ְ� ����� �������� ���ߴٸ�, ���� bestTime�� ��µ� ��.
        recordText.text = "Best Time: " + (int)bestTime;
    }

    void Start()
    {
        // ������ �ʱ�ȭ.
        survivalTime = 0f;
        isGameover = false;
    }
        
    void Update()
    {
        // ���ӿ����� �ƴ� ���ȸ�.
        if (!isGameover)
        {
            // ���� �ð� ����.
            survivalTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��Ͽ� ǥ��.
            timeText.text = "Time: " + (int)survivalTime;
        }
        else
        {
            // ���ӿ��� ���¿��� RŰ�� ���� ���. (�����)
            if (Input.GetKeyDown(KeyCode.R))       // GetKeyDown�� Ű�Է��� �����Ͽ� �Ұ��� ��ȯ��.
            {
                // Dodge ���� �� �ε�. LoadScene�� ����� ��, �ε�� ���� ���� ��Ͽ� �־�� �Ѵ�. �� �̸��� �ƴ� ���� ����� ���� ������ �̿��� ���� ȣ���� ���� �ִ�.
                SceneManager.LoadScene("Part3_Dodge_07_23");
            }
        }
        
    }       
}
