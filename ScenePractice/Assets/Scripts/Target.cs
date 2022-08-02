using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform _boss;
    public Transform _player;

    private void FixedUpdate()
    {
        /** ������ ��ġ�� ī�޶� ������ �����ϱ� ����, �÷��̾�� ���� ���� �߰� �������� target�� ������.
         * ī�޶�� �ش� target�� LookAt��. */
        transform.position = (_boss.position + _player.position) / 2;
    }
}
