using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal Tom = new Animal();      // new �����ڴ� Ŭ�����κ��� �ν��Ͻ��� �����Ѵ�. new ������ �ڿ��� �ش� Ŭ������ '������'�� �;� �Ѵ�.
        Tom.name = "��";                // ������Ʈ ���� ������ �޼ҵ带 ������ �Ѵ�. ��� �� ������ '�ʵ�'��� �Ѵ�.
        Tom.sound = "�Ŀ�!";            // ���� Ÿ���� ����(Ŭ���� ��)�� �����ϴ� �����δ� ������Ʈ�� �������� �ʰ�, �ݵ�� new �����ڸ� ��� �Ѵ�.
                                        // Animal Ÿ���� Tom�̶�� ������ ������ ������Ʈ �� ��ü�� �������� �ʰ� ������Ʈ�� ����Ű�� �������� �����Ѵ�.
        Animal Jerry = new Animal();
        Jerry.name = "����";
        Jerry.sound = "����!";

        //Jerry = Tom;                  // ���� Ÿ�� ������ �Ժη� ����� �������� ���� ����� �߻���ų �� �ִ�.
        //Jerry.name = "��Ű";          // ���� ������ ����Ű�� ������Ʈ�� �ּҰ��� ���� �ּҰ��� ����� ���. ���� ������ ����Ű�� ������Ʈ�� �̾ư� �Ǿ���.
                                        // � ������ ����Ű�� �ʴ� �̾ư� �� ������Ʈ�� ������ �ݷ��Ͱ� �ڵ����� �����Ѵ�.
                                        

        Tom.PlaySound();
        Jerry.PlaySound();
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
