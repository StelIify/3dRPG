using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 offSet;

    [Range(0.2f, 1f)]
    public float smoothFactor = 1f;

    private bool lookAtPlayer = false;

    private bool rotateAroundPlayer = true;

    public float speedOfRotation = 5f;

    private void Start()
    {
        offSet = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speedOfRotation, Vector3.up);

            offSet = camTurnAngle * offSet;
        }
        Vector3 newPos = playerTransform.position + offSet;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}
