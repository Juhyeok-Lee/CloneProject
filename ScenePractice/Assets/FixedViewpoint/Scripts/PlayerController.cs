using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Transform _cam;

    [SerializeField] private float _moveSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /** 플레이어 오브젝트의 회전을 캠과 동일하게 맞춰줌.
         * CamControl 스크립트에서 이미 캠이 보스를 가리키도록 설정했음. */
        transform.rotation = _cam.rotation;
        // _joystick.Horizontal과 Vertical은 -1~1 사이의 값.
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {            
            _rigidbody.velocity = transform.localRotation * new Vector3(
                _joystick.Horizontal * Time.deltaTime * _moveSpeed, 0,
                _joystick.Vertical * Time.deltaTime * _moveSpeed);
        }
    }
}
