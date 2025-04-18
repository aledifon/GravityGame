using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance;
    [SerializeField] float height;
    [SerializeField] float damping;
    [SerializeField] float rotationDamping;

    private void FixedUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    void MoveCamera()
    {
        // Calculate the camera position
        Vector3 desiredPosition = player.TransformPoint(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
    }

    void RotateCamera()
    {
        // Calculate the rotation
        Vector3 cameraToPlayer = player.position - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(cameraToPlayer, player.up);          
        // Apply the rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationDamping);
    }
}
