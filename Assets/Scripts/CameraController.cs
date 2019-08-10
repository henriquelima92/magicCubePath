using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    Left,
    Right,
    Top,
    Bottom
}
public class CameraController : MonoBehaviour
{
    public float Angle;
    public float RotationTime;
    public bool IsRotating = false;
    public Transform objectToRotate;

    public void RotateCube(int axis)
    {
        if(IsRotating == false)
        {
            switch(axis)
            {
                case 0:
                    StartCoroutine(Rotate(Vector3.up, RotationTime));
                    break;
                case 1:
                    StartCoroutine(Rotate(-Vector3.up, RotationTime));
                    break;
                case 2:
                    StartCoroutine(Rotate(Vector3.right, RotationTime));
                    break;
                case 3:
                    StartCoroutine(Rotate(Vector3.left, RotationTime));
                    break;
            }
        }
    }

    private void Update()
    {
        if(IsRotating == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(Rotate(-Vector3.up, RotationTime));
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(Rotate(Vector3.up, RotationTime));
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Rotate(Vector3.right, RotationTime));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Rotate(Vector3.left, RotationTime));
            }
        }  
    }

    private IEnumerator Rotate(Vector3 direction, float duration)
    {
        IsRotating = true;
        Quaternion fromRotation = objectToRotate.rotation;
        Quaternion toRotation = fromRotation * Quaternion.Euler(direction * Angle);

        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            objectToRotate.rotation = Quaternion.Slerp(fromRotation, toRotation, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToRotate.rotation = toRotation;
        IsRotating = false;
    }
}
