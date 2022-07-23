using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // 참조 타입을 응용하여 컴포넌트의 참조를 변수로 가져와서 사용할 수 있다.
    // 스크립트 코드 상에서 씬에 있는 오브젝트나 컴포넌트를 사용하려면 참조 타입의 변수를 만들어서, 오브젝트를 가리키게 하면 된다.
    public Rigidbody myRigidbody;      // 스크립트의 퍼블릭 변수는 인스펙터에서 수정할 수 있다.
                                       // 리지드바디는 컴포넌트이므로, MonoBehaviour을 상속한다. 따라서 new 연산자가 없이 선언할 수 있다.

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.AddForce(0, 500, 0);    // x,y,z 방향으로 입력한만큼 힘을 줌.
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
