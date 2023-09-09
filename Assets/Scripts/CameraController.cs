using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public static float xOffset = 0;
    void Start()
    {
        player = PlayerController.instance.transform;
    }


    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x + xOffset, player.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
