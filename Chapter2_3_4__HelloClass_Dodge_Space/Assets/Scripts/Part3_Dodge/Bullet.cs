using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float speed = 8f;
   
    void Start()
    {
        // bulletRigidbody ������ �ڽ��� ������ٵ� ������.
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ٵ��� �ӵ� = �� ���� * �̵� �ӷ�.
        // transform.forward�� ���� ���� ������Ʈ�� �� ������ ��Ÿ���� ���� ����.
        bulletRigidbody.velocity = transform.forward * speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ�� �ı�.
        Destroy(gameObject, 3f);        // Destroy(this)��� ���� �� ��. this�� ���� ��ũ��Ʈ �ڽ��� ����Ŵ.
    }

    private void OnTriggerEnter(Collider other) // �浹�� �ٸ� ���� ������Ʈ�� ������.
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���. (�÷��̾�� ź���� �浹���� ��.)
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();     // �浹�� ���� ������Ʈ�κ��� PlayerController ������Ʈ�� �޾�, ������ ������.

            if (playerController != null)   // �浹 ������Ʈ�κ��� PlayerController ������Ʈ�� �������� ���� �����ߴٸ�.
            {
                playerController.Die();
            }
        }
    }
}
