using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // ���� ������Ʈ�� 1�ʿ� Y���� �������� �� �� ȸ���� �� ��Ÿ��.
    public float rotationSpeed = 60f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �� �ʸ��� y���� �������� rotationSpeed��ŭ ȸ����.
        transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
    }
}
