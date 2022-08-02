using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    public Transform camAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.forward = camAxis.forward;
            _rigidbody.velocity = transform.localRotation * new Vector3(
                _joystick.Horizontal * Time.deltaTime * 100f, 0,
                _joystick.Vertical * Time.deltaTime * 100f);
        }     
    }
}
