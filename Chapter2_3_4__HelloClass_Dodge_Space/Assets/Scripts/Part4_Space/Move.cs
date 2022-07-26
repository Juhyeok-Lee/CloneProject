using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // ������ �ڽ� ������Ʈ�� Ʈ������.
    public Transform childTransform;

   
    void Start()
    {
        // ������Ʈ �ڽ��� ���� ��ġ�� (0, -1, 0)���� ������.
        transform.position = new Vector3(0, -1, 0);
        // �ڽ��� ���� ��ġ�� (0, 2, 0)���� ����.
        childTransform.localPosition = new Vector3(0, 2, 0);

        // �ڽ��� ���� ȸ���� (0, 0, 30)���� ����. rotation�� ���͸� �������� �ʵ��� ����.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
        // �ڽ��� ���� ȸ���� (0, 60, 0)���� ����.
        childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));

    }

    // Update is called once per frame
    void Update()
    {
        // ���� ����Ű�� ������ ������ ���� ��ȯ. �ʴ� (0, 1, 0)�� �ӵ��� �����̵�. (��ŸŸ���� ����Ͽ� ������ ������ �ƴ� �� ������ (0,1,0)��ŭ �̵��ϵ��� ��.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // ������ٵ� ������� �ʰ� transform.Translate�� ����Ͽ� ������Ʈ�� �������� ���� ����.
            //transform.Translate(new Vector3(0, 1, 0)*Time.deltaTime);
            transform.position = transform.position + transform.up * Time.deltaTime;
        }

        // �Ʒ��� ����Ű�� ������ ������ ���� ��ȯ. �ʴ� (0, -1, 0)�� �ӵ��� �����̵�.
        if (Input.GetKey(KeyCode.DownArrow))
        {       
            //Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            transform.position = transform.position + -transform.up * Time.deltaTime;
        }

        // ���� ����Ű�� ������ ������ ���� ��ȯ. 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // �ڽ��� �ʴ�(0, 0, 180)��ŭ ȸ��.
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
            // �ڽ� ������Ʈ�� �ʴ� (0, 180, 0)��ŭ ȸ��.
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }

        // ������ ����Ű�� ������ ������ ���� ��ȯ. 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // �ڽ��� �ʴ� (0, 0, -180)��ŭ ȸ��.
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
            // �ڽ� ������Ʈ�� �ʴ� (0, -180, 0)��ŭ ȸ��.
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
    }
}
