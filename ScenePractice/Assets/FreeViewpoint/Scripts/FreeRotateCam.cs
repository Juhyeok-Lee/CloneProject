using UnityEngine;
using UnityEngine.EventSystems;

public class FreeRotateCam : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject player;    
    public GameObject cam;
    public Transform camPivot;
    public float rotationSpeed = 0.4f;

    Vector3 beginPos;
    Vector3 draggingPos;
    
    float yAngle;    
    float yAngleTemp;

    private void Start()
    {        
        yAngle = camPivot.rotation.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        camPivot.position = player.transform.position;        
    }

    public void OnBeginDrag(PointerEventData beginPoint)
    {        
        beginPos = beginPoint.position;        
        yAngleTemp = yAngle;
    }

    public void OnDrag(PointerEventData draggingPoint)
    {        
        draggingPos = draggingPoint.position;

        yAngle = yAngleTemp + (draggingPos.x - beginPos.x) * 180 / Screen.width * rotationSpeed;
        
        camPivot.rotation = Quaternion.Euler(0f, yAngle, 0f);
    }
}