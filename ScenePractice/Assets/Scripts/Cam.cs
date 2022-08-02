using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public GameObject _player;
    public GameObject _boss;
    public Transform _camAxis;


    // Update is called once per frame
    void FixedUpdate()
    {
        // ī�޶� ���� player ������Ʈ�� ��ġ���� ����.
        _camAxis.position = _player.transform.position;
        /** ī�޶��� ��ġ�� boss ������Ʈ�� player ������Ʈ�� ������ ���� ������, 
         * player ������Ʈ���� 5��ŭ ������ ��ġ�� ����.
         * boss.transform.position���� player.transform.position�� ���Ͽ� ���⺤�͸� ���� �� ������ ���Ͽ� ��ġ�� ����.
         * boos ������Ʈ�� pivot�� player ������Ʈ�� pivot�� ������Ʈ �ϴ��� �ƴϱ⿡ ����� ī�޶��� ��ġ�� �����.
         * ���߿� ������ ����ϰ� �Ǹ�, ������Ʈ�� ���ϴܿ� pivot�� �����Ǳ� ������ ������ ���� ����. */
        transform.localPosition = (_boss.transform.position - _player.transform.position).normalized * -5 + new Vector3(0, 1.5f, 0);
    }
}
