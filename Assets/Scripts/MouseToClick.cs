using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToClick : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector3 mousePos, transPos, targetPos;

    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CalTargetPos();
        }
        MoveToTarget();
    }


    void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }
    void MoveToTarget()
    {
       transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
    }
}
