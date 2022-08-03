using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]

public class FreePlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Transform _cam;

    [SerializeField] private float _moveSpeed;


    // Update is called once per frame
    void FixedUpdate()
    {                      
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = _cam.rotation;            
            _rigidbody.velocity = transform.localRotation * new Vector3(
                _joystick.Horizontal * Time.deltaTime * _moveSpeed, 0,
                _joystick.Vertical * Time.deltaTime * _moveSpeed);
        }
    }
}
