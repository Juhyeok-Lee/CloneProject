using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCam : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject player;
    public Transform camPivot;
    public float rotationSpeed = 0.4f;

    Vector3 beginPos;
    Vector3 draggingPos;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;

    private void Start()
    {
        xAngle = camPivot.rotation.eulerAngles.x;
        yAngle = camPivot.rotation.eulerAngles.y;
    }

    private void Update()
    {
        camPivot.position = player.transform.position;
    }

    public void OnBeginDrag(PointerEventData beginPoint)
    {
        Debug.Log("��ġ");
        beginPos = beginPoint.position;

        xAngleTemp = xAngle;
        yAngleTemp = yAngle;
    }

    public void OnDrag(PointerEventData draggingPoint)
    {
        Debug.Log("��ġ ��");
        draggingPos = draggingPoint.position;

        yAngle = yAngleTemp + (draggingPos.x - beginPos.x) * 180 / Screen.width * rotationSpeed;
        xAngle = xAngleTemp - (draggingPos.y - beginPos.y) * 90 / Screen.height * rotationSpeed;

        if (xAngle > 30) xAngle = 30;
        if (xAngle < -60) xAngle = -60;

        camPivot.rotation = Quaternion.Euler(xAngle, yAngle, 0.0f);
    }
}