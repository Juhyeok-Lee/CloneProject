using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 게임 오브젝트가 1초에 Y축을 기준으로 몇 도 회전할 지 나타냄.
    public float rotationSpeed = 60f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 매 초마다 y축을 기준으로 rotationSpeed만큼 회전함.
        transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
    }
}
