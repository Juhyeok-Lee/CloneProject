using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform _boss;
    public Transform _player;

    private void FixedUpdate()
    {
        /** 보스의 위치로 카메라 시점을 고정하기 위해, 플레이어와 보스 사이 중간 지점으로 target을 설정함.
         * 카메라는 해당 target을 LookAt함. */
        transform.position = (_boss.position + _player.position) / 2;
    }
}
