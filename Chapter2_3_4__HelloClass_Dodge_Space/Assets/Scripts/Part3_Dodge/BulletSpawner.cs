using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;     // 생성할 탄알의 원본 프리팹.
    public float spawnRateMin = 0.5f;   // 탄알 생성의 최소 주기.
    public float spawnRateMax = 3f;     // 탄알 생성의 최대 주기.

    private Transform target;           // 조준할 대상 게임 오브젝트의 트랜스폼 컴포넌트.
    private float spawnRate;            // 탄알 생성 주기. RateMin과 RateMax 사이의 랜덤 값으로 설정.
    private float timeAfterSpawn;       // 탄알 생성으로부터 지난 시간.
       
    void Start()
    {
        // 탄알 생성으로부터 지난 시간을 0으로 초기화함.
        timeAfterSpawn = 0f;
        // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이의 랜덤한 값으로 지정.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController를 가진 게임 오브젝트를 찾아 그것의 컴포넌트를 반환함. 그리고 그것으로부터 연결된 오브젝트의 트랜스폼을 target에 할당.
        // Find 함수는 제네릭 타입을 받아, 해당 타입의 컴포넌트를 반환함. 속도가 느리므로 Start나 Awake 등 한 번 실행되는 메소드에서만 사용할 것.
        // FindObjectOfType이 아닌 FindObjectsOfType은 '배열'을 반환함.
        target = FindObjectOfType<PlayerController>().transform;    //
    }
        
    void Update()
    {
        // 한 프레임이 경과할 때마다, 프레임 사이의 시간 간격을 timeAfterSpawn에 저장함.
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점부터 누적된 시간이 생성 주기보다 커졌다면.
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋.
            timeAfterSpawn = 0f;

            // bullet 오브젝트의 인스턴스를 생성.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // bullet이 target을 향하도록 함.
            bullet.transform.LookAt(target);       // transform.LookAt 메소드는 매개변수로 다른 게임 오브젝트의 transform을 직접 받아, 해당 방향을 오브젝트가 바라보게 한다.
            // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이의 랜덤한 값으로 재지정.
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        
    }
}
