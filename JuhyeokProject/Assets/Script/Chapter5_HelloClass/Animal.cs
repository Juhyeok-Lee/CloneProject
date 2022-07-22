using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    // 동물에 대한 변수
    public string name;         // 클래스의 멤버들은 별도로 접근 제한자를 설정하지 않으면, 기본적으로 private을 적용받아 외부에 공개하지 않는다.
    public string sound;

    // 울음소리를 재생하는 메소드
    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);
    }

}