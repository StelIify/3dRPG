using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offSet;
    void Start()
    {
        offSet = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offSet;
        
    }
}
