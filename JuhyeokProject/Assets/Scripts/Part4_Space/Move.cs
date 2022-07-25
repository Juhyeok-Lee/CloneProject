using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 움직일 자식 오브젝트의 트랜스폼.
    public Transform childTransform;

   
    void Start()
    {
        // 오브젝트 자신의 전역 위치를 (0, -1, 0)으로 변경함.
        transform.position = new Vector3(0, -1, 0);
        // 자식의 지역 위치를 (0, 2, 0)으로 변경.
        childTransform.localPosition = new Vector3(0, 2, 0);

        // 자신의 전역 회전을 (0, 0, 30)으로 변경. rotation에 벡터를 대입하지 않도록 주의.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
        // 자식의 지역 회전을 (0, 60, 0)으로 변경.
        childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));

    }

    // Update is called once per frame
    void Update()
    {
        // 위쪽 방향키를 누르고 있으면 참을 반환. 초당 (0, 1, 0)의 속도로 평행이동. (델타타임을 사용하여 프레임 단위가 아닌 초 단위로 (0,1,0)만큼 이동하도록 함.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 리지드바디를 사용하지 않고 transform.Translate를 사용하여 오브젝트의 포지션을 직접 변경.
            //transform.Translate(new Vector3(0, 1, 0)*Time.deltaTime);
            transform.position = transform.position + transform.up * Time.deltaTime;
        }

        // 아래쪽 방향키를 누르고 있으면 참을 반환. 초당 (0, -1, 0)의 속도로 평행이동.
        if (Input.GetKey(KeyCode.DownArrow))
        {       
            //Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            transform.position = transform.position + -transform.up * Time.deltaTime;
        }

        // 왼쪽 방향키를 누르고 있으면 참을 반환. 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 자신을 초당(0, 0, 180)만큼 회전.
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
            // 자식 오브젝트를 초당 (0, 180, 0)만큼 회전.
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }

        // 오른쪽 방향키를 누르고 있으면 참을 반환. 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 자신을 초당 (0, 0, -180)만큼 회전.
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
            // 자식 오브젝트를 초당 (0, -180, 0)만큼 회전.
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
    }
}
