using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_07_20 : MonoBehaviour     // 유니티 게임 오브젝트 클래스.
{

    // 플레이어와 관련된 데이터를 전역변수(멤버변수)로 선언.
    int level = 5;                            
    float strength = 15.5f;
    string title = "전설의";
    string playerName = "나검사";  
    bool isFullLevel = false; 
    int health = 30;
    int mana = 25;
    int exp = 1500;
    
    

    // 7. 함수 (메소드).
    int Heal(int currentHealth)
    {
        currentHealth += 10;
        Debug.Log("힐을 받았습니다. " + currentHealth);
        return currentHealth;
    }

    void Healing()
    {
        health += 10;
        Debug.Log("힐을 받았습니다. " + health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
        {
            result="이겼습니다.";
        }
        else
        {
            result = "졌습니다.";
        }

        return result;
    }


    // Start is called before the first frame update
    void Start()
    {
        // 콘솔창 출력.
        Debug.Log("Hello, Unity!");

        // 1. 변수.
        // 주로 사용하는 네 가지 데이터 타입의 변수를 정의.
        //int level = 5;                            // 플레이어 레벨. 정수형.
        //float strength = 15.5f;              // 플레이어의 근력 스탯. 실수형.
        //string playerName = "나검사";   // 플레이어 이름.
        //bool isFullLevel = false;             // 플레이어가 최고 레벨인지 점검.

        // 생성된 변수를 Debug.Log 함수에서 호출.
        Debug.Log("용사의 이름은?");
        Debug.Log(playerName);
        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 힘은?");
        Debug.Log(strength);
        Debug.Log("용사는 만렙인가?");
        Debug.Log(isFullLevel);

        // 2. 그룹형 변수.
        // 2-1. 배열.
        // string 타입의 배열을 선언.
        string[] monsters = { "슬라임", "사막뱀", "악마" };
        // ㄴ 전부 같은 코드.
        // string[] monsters = new string[] { "슬라임", "사막뱀", "악마"};
        // string[] monsters = new string[3] { "슬라임", "사막뱀", "악마" };

        Debug.Log("맵에 존재하는 몬스터");
        // 배열의 원소는 index가 0부터 시작함. index가 n이면 n+1번째 원소를 가리킴.
        Debug.Log(monsters[0]); 
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]);

        // 몬스터 레벨을 저장하는 정수 타입 배열을 새로이 생성.
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("맵에 존재하는 몬스터의 레벨");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        // 2-2. 리스트.
        List<string> items = new List<string>();
        // Add 함수를 이용하여 리스트 원소를 삽입.
        items.Add("생명 물약 30");
        items.Add("마나 물약 30");

        Debug.Log("가지고 있는 아이템");
        // 리스트의 원소 역시 배열과 마찬가지로 [] 연산자를 이용하여 출력.
        Debug.Log(items[0]);
        Debug.Log(items[1]);

        // RemoveAt 함수를 이용하여 특정 인덱스의 원소를 삭제.
        //items.RemoveAt(0);     // 0번 원소인 생명 물약 30이 삭제됨.

        Debug.Log("가지고 있는 아이템");       
        Debug.Log(items[0]);        // 마나 물약 30이 0번 원소로 당겨짐.
        //Debug.Log(items[1]);     // 2번째 원소가 없으므로 오류 출력.

        // 3. 연산자.
        //int exp = 1500;     // 플레이어의 경험치를 저장하는 변수.

        // 이항 연산자.
        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;
               
        Debug.Log("용사의 총 경험치는?");
        Debug.Log(exp);
        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 힘은?");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);        // 다음 레벨까지 남은 경험치. (레벨업까지 필요한 총 경험치 - 현재 경험치)
        Debug.Log("다음 레벨까지 남은 경험치는?");
        Debug.Log(nextExp);

        // 문자열 연산자.
        //string title = "전설의";
        Debug.Log("용사의 이름은?");
        Debug.Log(title + " " + playerName);    // 문자열에 대한 + 연산자를 사용하여 문자열을 이음.

        // 관계 연산자.
        const int fullLevel = 99;
        isFullLevel = level == fullLevel;   // 레벨이 99이면 최고 레벨.
        Debug.Log("지금 용사는 만렙입니까? " + isFullLevel);

        bool isEndTutorial = level > 10;    // 레벨이 10이 넘으면 튜토리얼을 종료.
        Debug.Log("튜토리얼이 끝난 용사입니까? " + isEndTutorial);

        // 논리 연산자.
        //int health = 30;    // 현재 체력.
        //int mana = 25;     // 현재 마나.
        //bool isBadCondition = health <= 50 && mana <= 20;   and 연산자로 플레이어 상태를 체크.
        bool isBadCondition = health <= 50 || mana <= 20;    // or 연산자로 플레이어 상태를 체크.
        Debug.Log("용사의 상태가 나쁩니까? " + isBadCondition);

        // 삼항 연산자.
        string condition = isBadCondition ? "나쁨" : "좋음";

        // 4. 키워드.
        // 프로그래밍 언어를 구성하는 특별한 단어.
        // 변수명이나 값으로 사용할 수 없음.

        // 5. 조건문.
        // if문. () 내부의 문장이 참일 때에만 블록 내부 코드를 수행함.
        if (condition == "나쁨")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요.");
        }
        else
        {
            Debug.Log("플레이어 상태가 좋습니다.");
        }

        if (isBadCondition && items[0] == "생명 물약 30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명 물약 30을 사용하였습니다.");
        }
        else if (isBadCondition && items[0] == "마나 물약 30")       
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나 물약 30을 사용하였습니다.");
        }

        // switch-case문.
        // 변수 값에 따라 case를 실행.
        // break 키워드를 반드시 사용할 것.
        switch (monsters[1])
        {
            case "슬라임":     // 여러 케이스가 하나의 명령으로 이어지도록 할 수 있음.
            case "사막뱀":
                Debug.Log("소형 몬스터가 출현!");
                break;
            case "악마":
                Debug.Log("중형 몬스터가 출현!");
                break;
            case "골렘":
                Debug.Log("대형 몬스터가 출현!");
                break;
            default:        // 어떤 케이스에도 걸리지 않을 때 디폴트로 수행되는 명령.
                Debug.Log("??? 몬스터가 출현!");
                break;
        }

        // 6. 반복문.
        // while문.
        while (health>0)
        {
            health--;
            if (health > 0)
            {
                Debug.Log("독 데미지를 입었습니다. " + health);
            }
            else
            {
                Debug.Log("사망했습니다.");
            }

            if (health == 10)
            {
                Debug.Log("해독제를 사용합니다.");
                break;  // 반복문에서 빠져나옴.
            }

        }

        // for문.
        for (int count = 0; count < 10; count++) 
        {
            health++;
            Debug.Log("붕대로 치료 중... " + health);
        }

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("이 지역에 있는 몬스터: " + monsters[index]);
        }

        // foreach문.
        // 그룹형 변수 내부의 원소를 받아 반복문을 수행.
        foreach(string monster in monsters)
        {
            Debug.Log("이 지역에 있는 몬스터: " + monster);
        }

        // 7. 함수.
        health = Heal(health);
        Healing();
        for(int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("용사는 " + monsters[index] + "에게 " + Battle(monsterLevel[index]));
        }

        // 8. 클래스.
        // 하나의 사물(오브젝트)과 대응하는 로직.
        // 유니티에서는 대개 하나의 파일에 하나의 클래스를 대응하도록 한다.
        // 클래스를 상속하면 자식 클래스는 부모 클래스의 멤버변수와 멤버함수를 사용할 수 있다.
        Player player = new Player();     // 인스턴스화. 정의된 클래스를 변수 초기화로 실체화.
        player.id = 0;
        player.name = "나법사";
        player.title = "현명한";
        player.strength = 2.4f;
        player.weapon = "나무 지팡이";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "의 레벨은 " + player.level + "입니다.");
        Debug.Log(player.Move());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
