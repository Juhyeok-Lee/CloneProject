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
        /** �÷��̾� ������Ʈ�� ȸ���� ķ�� �����ϰ� ������.
         * CamControl ��ũ��Ʈ���� �̹� ķ�� ������ ����Ű���� ��������. */
        transform.rotation = _cam.rotation;
        // _joystick.Horizontal�� Vertical�� -1~1 ������ ��.
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {            
            _rigidbody.velocity = transform.localRotation * new Vector3(
                _joystick.Horizontal * Time.deltaTime * _moveSpeed, 0,
                _joystick.Vertical * Time.deltaTime * _moveSpeed);
        }
    }
}
