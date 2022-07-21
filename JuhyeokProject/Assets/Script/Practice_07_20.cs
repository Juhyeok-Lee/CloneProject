using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_07_20 : MonoBehaviour     // ����Ƽ ���� ������Ʈ Ŭ����.
{

    // �÷��̾�� ���õ� �����͸� ��������(�������)�� ����.
    int level = 5;                            
    float strength = 15.5f;
    string title = "������";
    string playerName = "���˻�";  
    bool isFullLevel = false; 
    int health = 30;
    int mana = 25;
    int exp = 1500;
    
    

    // 7. �Լ� (�޼ҵ�).
    int Heal(int currentHealth)
    {
        currentHealth += 10;
        Debug.Log("���� �޾ҽ��ϴ�. " + currentHealth);
        return currentHealth;
    }

    void Healing()
    {
        health += 10;
        Debug.Log("���� �޾ҽ��ϴ�. " + health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
        {
            result="�̰���ϴ�.";
        }
        else
        {
            result = "�����ϴ�.";
        }

        return result;
    }


    // Start is called before the first frame update
    void Start()
    {
        // �ܼ�â ���.
        Debug.Log("Hello, Unity!");

        // 1. ����.
        // �ַ� ����ϴ� �� ���� ������ Ÿ���� ������ ����.
        //int level = 5;                            // �÷��̾� ����. ������.
        //float strength = 15.5f;              // �÷��̾��� �ٷ� ����. �Ǽ���.
        //string playerName = "���˻�";   // �÷��̾� �̸�.
        //bool isFullLevel = false;             // �÷��̾ �ְ� �������� ����.

        // ������ ������ Debug.Log �Լ����� ȣ��.
        Debug.Log("����� �̸���?");
        Debug.Log(playerName);
        Debug.Log("����� ������?");
        Debug.Log(level);
        Debug.Log("����� ����?");
        Debug.Log(strength);
        Debug.Log("���� �����ΰ�?");
        Debug.Log(isFullLevel);

        // 2. �׷��� ����.
        // 2-1. �迭.
        // string Ÿ���� �迭�� ����.
        string[] monsters = { "������", "�縷��", "�Ǹ�" };
        // �� ���� ���� �ڵ�.
        // string[] monsters = new string[] { "������", "�縷��", "�Ǹ�"};
        // string[] monsters = new string[3] { "������", "�縷��", "�Ǹ�" };

        Debug.Log("�ʿ� �����ϴ� ����");
        // �迭�� ���Ҵ� index�� 0���� ������. index�� n�̸� n+1��° ���Ҹ� ����Ŵ.
        Debug.Log(monsters[0]); 
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]);

        // ���� ������ �����ϴ� ���� Ÿ�� �迭�� ������ ����.
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("�ʿ� �����ϴ� ������ ����");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        // 2-2. ����Ʈ.
        List<string> items = new List<string>();
        // Add �Լ��� �̿��Ͽ� ����Ʈ ���Ҹ� ����.
        items.Add("���� ���� 30");
        items.Add("���� ���� 30");

        Debug.Log("������ �ִ� ������");
        // ����Ʈ�� ���� ���� �迭�� ���������� [] �����ڸ� �̿��Ͽ� ���.
        Debug.Log(items[0]);
        Debug.Log(items[1]);

        // RemoveAt �Լ��� �̿��Ͽ� Ư�� �ε����� ���Ҹ� ����.
        //items.RemoveAt(0);     // 0�� ������ ���� ���� 30�� ������.

        Debug.Log("������ �ִ� ������");       
        Debug.Log(items[0]);        // ���� ���� 30�� 0�� ���ҷ� �����.
        //Debug.Log(items[1]);     // 2��° ���Ұ� �����Ƿ� ���� ���.

        // 3. ������.
        //int exp = 1500;     // �÷��̾��� ����ġ�� �����ϴ� ����.

        // ���� ������.
        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;
               
        Debug.Log("����� �� ����ġ��?");
        Debug.Log(exp);
        Debug.Log("����� ������?");
        Debug.Log(level);
        Debug.Log("����� ����?");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);        // ���� �������� ���� ����ġ. (���������� �ʿ��� �� ����ġ - ���� ����ġ)
        Debug.Log("���� �������� ���� ����ġ��?");
        Debug.Log(nextExp);

        // ���ڿ� ������.
        //string title = "������";
        Debug.Log("����� �̸���?");
        Debug.Log(title + " " + playerName);    // ���ڿ��� ���� + �����ڸ� ����Ͽ� ���ڿ��� ����.

        // ���� ������.
        const int fullLevel = 99;
        isFullLevel = level == fullLevel;   // ������ 99�̸� �ְ� ����.
        Debug.Log("���� ���� �����Դϱ�? " + isFullLevel);

        bool isEndTutorial = level > 10;    // ������ 10�� ������ Ʃ�丮���� ����.
        Debug.Log("Ʃ�丮���� ���� ����Դϱ�? " + isEndTutorial);

        // �� ������.
        //int health = 30;    // ���� ü��.
        //int mana = 25;     // ���� ����.
        //bool isBadCondition = health <= 50 && mana <= 20;   and �����ڷ� �÷��̾� ���¸� üũ.
        bool isBadCondition = health <= 50 || mana <= 20;    // or �����ڷ� �÷��̾� ���¸� üũ.
        Debug.Log("����� ���°� ���޴ϱ�? " + isBadCondition);

        // ���� ������.
        string condition = isBadCondition ? "����" : "����";

        // 4. Ű����.
        // ���α׷��� �� �����ϴ� Ư���� �ܾ�.
        // �������̳� ������ ����� �� ����.

        // 5. ���ǹ�.
        // if��. () ������ ������ ���� ������ ��� ���� �ڵ带 ������.
        if (condition == "����")
        {
            Debug.Log("�÷��̾� ���°� ���ڴ� �������� ����ϼ���.");
        }
        else
        {
            Debug.Log("�÷��̾� ���°� �����ϴ�.");
        }

        if (isBadCondition && items[0] == "���� ���� 30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("���� ���� 30�� ����Ͽ����ϴ�.");
        }
        else if (isBadCondition && items[0] == "���� ���� 30")       
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("���� ���� 30�� ����Ͽ����ϴ�.");
        }

        // switch-case��.
        // ���� ���� ���� case�� ����.
        // break Ű���带 �ݵ�� ����� ��.
        switch (monsters[1])
        {
            case "������":     // ���� ���̽��� �ϳ��� ������� �̾������� �� �� ����.
            case "�縷��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "�Ǹ�":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            default:        // � ���̽����� �ɸ��� ���� �� ����Ʈ�� ����Ǵ� ���.
                Debug.Log("??? ���Ͱ� ����!");
                break;
        }

        // 6. �ݺ���.
        // while��.
        while (health>0)
        {
            health--;
            if (health > 0)
            {
                Debug.Log("�� �������� �Ծ����ϴ�. " + health);
            }
            else
            {
                Debug.Log("����߽��ϴ�.");
            }

            if (health == 10)
            {
                Debug.Log("�ص����� ����մϴ�.");
                break;  // �ݺ������� ��������.
            }

        }

        // for��.
        for (int count = 0; count < 10; count++) 
        {
            health++;
            Debug.Log("�ش�� ġ�� ��... " + health);
        }

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("�� ������ �ִ� ����: " + monsters[index]);
        }

        // foreach��.
        // �׷��� ���� ������ ���Ҹ� �޾� �ݺ����� ����.
        foreach(string monster in monsters)
        {
            Debug.Log("�� ������ �ִ� ����: " + monster);
        }

        // 7. �Լ�.
        health = Heal(health);
        Healing();
        for(int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("���� " + monsters[index] + "���� " + Battle(monsterLevel[index]));
        }

        // 8. Ŭ����.
        // �ϳ��� �繰(������Ʈ)�� �����ϴ� ����.
        // ����Ƽ������ �밳 �ϳ��� ���Ͽ� �ϳ��� Ŭ������ �����ϵ��� �Ѵ�.
        // Ŭ������ ����ϸ� �ڽ� Ŭ������ �θ� Ŭ������ ��������� ����Լ��� ����� �� �ִ�.
        Player player = new Player();     // �ν��Ͻ�ȭ. ���ǵ� Ŭ������ ���� �ʱ�ȭ�� ��üȭ.
        player.id = 0;
        player.name = "������";
        player.title = "������";
        player.strength = 2.4f;
        player.weapon = "���� ������";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "�� ������ " + player.level + "�Դϴ�.");
        Debug.Log(player.Move());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
