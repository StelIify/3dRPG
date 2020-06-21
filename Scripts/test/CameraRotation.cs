using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    
    float camPosX = -2.303398f;
    float camPosY = 3.6435f;
    float camPosZ = -5.162334f;
    float camRotationX = 15.337f;
    float camRotationY = -0.7640001f;
    float camRotationZ = 0;
    float turnSpeed = 1f;
    Vector3 offset = new Vector3(0, 0, 0);
    Vector3 abovePlayer = new Vector3(25, 25, 25);

    public Transform player;
    private void Start()
    {
        offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);
    }

    private void Update()
    {
        abovePlayer = new Vector3(player.position.x, player.position.y + 1, player.position.z);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * offset;
        transform.position = player.position + offset;
        transform.LookAt(abovePlayer);
    }
    

    
}
