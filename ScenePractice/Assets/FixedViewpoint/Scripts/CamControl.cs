using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // 고정 시점 카메라를 설정.
    // 플레이어 오브젝트, 카메라는 모두 보스를 향함.
    // 카메라는 플레이어에서 y=1, z=-5만큼 떨어져있음.

    // 보스 오브젝트 방향을 가리키기 위해 보스 오브젝트와 플레이어 오브젝트를 선언.
    public GameObject _player;    
    public GameObject _boss;   
    
    void FixedUpdate()
    {        
        // 플레이어의 피봇이 y값이 0이 아니라, 임의로 설정하였음.
        Vector3 playerPivot = _player.transform.position;
        playerPivot.y = 0;

        Vector3 _dir = (_boss.transform.position -playerPivot).normalized;
        transform.rotation = Quaternion.LookRotation(_dir);                     
    }
}
