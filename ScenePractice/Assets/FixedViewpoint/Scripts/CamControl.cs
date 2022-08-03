using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // ���� ���� ī�޶� ����.
    // �÷��̾� ������Ʈ, ī�޶�� ��� ������ ����.
    // ī�޶�� �÷��̾�� y=1, z=-5��ŭ ����������.

    // ���� ������Ʈ ������ ����Ű�� ���� ���� ������Ʈ�� �÷��̾� ������Ʈ�� ����.
    public GameObject _player;    
    public GameObject _boss;   
    
    void FixedUpdate()
    {        
        // �÷��̾��� �Ǻ��� y���� 0�� �ƴ϶�, ���Ƿ� �����Ͽ���.
        Vector3 playerPivot = _player.transform.position;
        playerPivot.y = 0;

        Vector3 _dir = (_boss.transform.position -playerPivot).normalized;
        transform.rotation = Quaternion.LookRotation(_dir);                     
    }
}
