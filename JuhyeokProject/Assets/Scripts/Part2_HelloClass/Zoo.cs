using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal Tom = new Animal();      // new 연산자는 클래스로부터 인스턴스를 생성한다. new 연산자 뒤에는 해당 클래스의 '생성자'가 와야 한다.
        Tom.name = "톰";                // 오브젝트 내의 변수나 메소드를 멤버라고 한다. 멤버 중 변수를 '필드'라고 한다.
        Tom.sound = "냐옹!";            // 참조 타입의 변수(클래스 등)는 선언하는 것으로는 오브젝트가 생성되지 않고, 반드시 new 연산자를 써야 한다.
                                        // Animal 타입의 Tom이라는 변수는 생성된 오브젝트 그 자체를 저장하지 않고 오브젝트를 가리키는 참조값을 저장한다.
        Animal Jerry = new Animal();
        Jerry.name = "제리";
        Jerry.sound = "찍찍!";

        //Jerry = Tom;                  // 참조 타입 변수는 함부로 덮어쓰면 예상하지 못한 결과를 발생시킬 수 있다.
        //Jerry.name = "미키";          // 제리 변수가 가리키는 오브젝트의 주소값에 톰의 주소값을 덮어씌운 결과. 본래 제리가 가리키던 오브젝트는 미아가 되었다.
                                        // 어떤 변수도 가리키지 않는 미아가 된 오브젝트는 가비지 콜렉터가 자동으로 정리한다.
                                        

        Tom.PlaySound();
        Jerry.PlaySound();
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
