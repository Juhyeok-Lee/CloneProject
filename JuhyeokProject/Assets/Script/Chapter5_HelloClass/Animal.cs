using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    // ������ ���� ����
    public string name;         // Ŭ������ ������� ������ ���� �����ڸ� �������� ������, �⺻������ private�� ����޾� �ܺο� �������� �ʴ´�.
    public string sound;

    // �����Ҹ��� ����ϴ� �޼ҵ�
    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);
    }

}