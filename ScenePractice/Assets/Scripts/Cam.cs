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
        // 카메라 축이 player 오브젝트와 겹치도록 설정.
        _camAxis.position = _player.transform.position;
        /** 카메라의 위치를 boss 오브젝트와 player 오브젝트를 연결한 선분 위에서, 
         * player 오브젝트보다 5만큼 떨어진 위치로 설정.
         * boss.transform.position에서 player.transform.position을 감하여 방향벡터를 만든 뒤 음수를 곱하여 위치를 설정.
         * boos 오브젝트의 pivot과 player 오브젝트의 pivot이 오브젝트 하단이 아니기에 현재는 카메라의 위치가 어색함.
         * 나중에 에셋을 사용하게 되면, 오브젝트의 최하단에 pivot이 설정되기 때문에 문제가 없을 예정. */
        transform.localPosition = (_boss.transform.position - _player.transform.position).normalized * -5 + new Vector3(0, 1.5f, 0);
    }
}
