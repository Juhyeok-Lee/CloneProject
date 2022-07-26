using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;     // ������ ź���� ���� ������.
    public float spawnRateMin = 0.5f;   // ź�� ������ �ּ� �ֱ�.
    public float spawnRateMax = 3f;     // ź�� ������ �ִ� �ֱ�.

    private Transform target;           // ������ ��� ���� ������Ʈ�� Ʈ������ ������Ʈ.
    private float spawnRate;            // ź�� ���� �ֱ�. RateMin�� RateMax ������ ���� ������ ����.
    private float timeAfterSpawn;       // ź�� �������κ��� ���� �ð�.
       
    void Start()
    {
        // ź�� �������κ��� ���� �ð��� 0���� �ʱ�ȭ��.
        timeAfterSpawn = 0f;
        // ź�� ���� ������ spawnRateMin�� spawnRateMax ������ ������ ������ ����.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController�� ���� ���� ������Ʈ�� ã�� �װ��� ������Ʈ�� ��ȯ��. �׸��� �װ����κ��� ����� ������Ʈ�� Ʈ�������� target�� �Ҵ�.
        // Find �Լ��� ���׸� Ÿ���� �޾�, �ش� Ÿ���� ������Ʈ�� ��ȯ��. �ӵ��� �����Ƿ� Start�� Awake �� �� �� ����Ǵ� �޼ҵ忡���� ����� ��.
        // FindObjectOfType�� �ƴ� FindObjectsOfType�� '�迭'�� ��ȯ��.
        target = FindObjectOfType<PlayerController>().transform;    //
    }
        
    void Update()
    {
        // �� �������� ����� ������, ������ ������ �ð� ������ timeAfterSpawn�� ������.
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� �������� ������ �ð��� ���� �ֱ⺸�� Ŀ���ٸ�.
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����.
            timeAfterSpawn = 0f;

            // bullet ������Ʈ�� �ν��Ͻ��� ����.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // bullet�� target�� ���ϵ��� ��.
            bullet.transform.LookAt(target);       // transform.LookAt �޼ҵ�� �Ű������� �ٸ� ���� ������Ʈ�� transform�� ���� �޾�, �ش� ������ ������Ʈ�� �ٶ󺸰� �Ѵ�.
            // ź�� ���� ������ spawnRateMin�� spawnRateMax ������ ������ ������ ������.
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        
    }
}
