using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // ���� Ÿ���� �����Ͽ� ������Ʈ�� ������ ������ �����ͼ� ����� �� �ִ�.
    // ��ũ��Ʈ �ڵ� �󿡼� ���� �ִ� ������Ʈ�� ������Ʈ�� ����Ϸ��� ���� Ÿ���� ������ ����, ������Ʈ�� ����Ű�� �ϸ� �ȴ�.
    public Rigidbody myRigidbody;      // ��ũ��Ʈ�� �ۺ� ������ �ν����Ϳ��� ������ �� �ִ�.
                                       // ������ٵ�� ������Ʈ�̹Ƿ�, MonoBehaviour�� ����Ѵ�. ���� new �����ڰ� ���� ������ �� �ִ�.

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.AddForce(0, 500, 0);    // x,y,z �������� �Է��Ѹ�ŭ ���� ��.
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
