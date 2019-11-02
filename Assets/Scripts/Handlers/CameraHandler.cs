using System.Collections;
using UnityEngine;

public class CameraHandler
{
    private float angle;
    private float rotationTime;
    private bool isRotating = false;
    private Transform objectToRotate;

    public CameraHandler(float rotationTime, Transform objectToRotate)
    {
        angle = 90f;
        this.rotationTime = rotationTime;
        this.objectToRotate = objectToRotate;
    }

    public IEnumerator Rotate(Vector3 direction)
    {
        if (isRotating == true)
            yield break;

        isRotating = true;
        Quaternion fromRotation = objectToRotate.rotation;
        Quaternion toRotation = fromRotation * Quaternion.Euler(direction * angle);

        float elapsedTime = 0;
        while (elapsedTime < rotationTime)
        {
            objectToRotate.rotation = Quaternion.Slerp(fromRotation, toRotation, (elapsedTime / rotationTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToRotate.rotation = toRotation;
        isRotating = false;
    }
}
