using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject targetObject;

    public float cameraXPosition;
    public float cameraYPosition;
    public float cameraZPosition;

    void Update()
    {
        Vector3 targetPosition = targetObject.transform.position;
        targetPosition.x = targetObject.transform.position.x + cameraXPosition;
        targetPosition.y = cameraYPosition;
        targetPosition.z = targetObject.transform.position.z + cameraZPosition;

        transform.position = targetPosition;
    }
}
