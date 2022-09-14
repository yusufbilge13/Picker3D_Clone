using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PickerMovement : MonoBehaviour
{
    Vector3 worldPosition;
    public static float swipeSpeed = 5.0f;
    public static float moveSpeed = 8.0f;
    private bool isStart = false;
    [SerializeField] private GameObject pickerCameraParent;
    private Camera pickerCamera;
    public static float timee = 0;

    private void Start()
    {
        pickerCamera = Camera.main; 
    }
    private void FixedUpdate()
    {
        if (timee > 0.0f && FinishTrigger.isLevelOver)
        {
            timee = timee - Time.fixedDeltaTime;
            if (timee <= 0.0f)
            {
                FinishTrigger.isLevelOver = false;
            }
        }
        if (Input.GetMouseButton(0) || isStart)
        {
            isStart = true;
            pickerCameraParent.transform.Translate(new Vector3(0, 0, moveSpeed * Time.fixedDeltaTime));
            transform.position += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = pickerCamera.transform.localPosition.z;

        Ray ray = pickerCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 hitVec = hit.point;
            hitVec.y = gameObject.transform.localPosition.y;
            hitVec.z = gameObject.transform.localPosition.z;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, hitVec, Time.fixedDeltaTime * swipeSpeed);
        }
    }
}
