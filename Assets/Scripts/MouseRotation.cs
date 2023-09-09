using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{


    float angle;
    Transform player;
    Vector3 mousePos;
    Vector3 screenCenter;
    private void Start()
    {
        player = PlayerController.instance.transform;
    }
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        screenCenter = Camera.main.ScreenToWorldPoint(screenCenter);

        angle = Mathf.Atan2( mousePos.y - screenCenter.y,   mousePos.x - screenCenter.x + CameraController.xOffset) * Mathf.Rad2Deg;

        if(angle >= 100 && angle <= 180 || angle >= -180  && angle <= -100)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }else if(angle <= 100 && angle >= 0 || angle >= -100 && angle <= 0) {
            transform.localScale = new Vector3(1, 1, 1);

        }
       
        
        transform.localRotation =  Quaternion.Euler(0, 0, angle) ;


    }
}
