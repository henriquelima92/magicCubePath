using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum Axis
{
    Top = 0,
    Bottom = 1,
    Right = 2,
    Left = 3,
    CenterLeft = 4,
    CenterRight = 5
}

public class CameraController : MonoBehaviour
{
    public float RotationTime;
    public Transform ObjectToRotate;

    private CameraHandler cameraHandler;

    private void Start()
    {
        cameraHandler = new CameraHandler(RotationTime, ObjectToRotate);
    }

    [EnumAction(typeof(Axis))]
    public void RotateCube(int axis)
    {
        switch(axis)
        {
            case (int)Axis.Top:
                StartCoroutine(cameraHandler.Rotate(Vector3.right));
            break;
            case (int)Axis.Bottom:
                StartCoroutine(cameraHandler.Rotate(Vector3.left));
            break;
            case (int)Axis.Right:
                StartCoroutine(cameraHandler.Rotate(-Vector3.up));
            break;
            case (int)Axis.Left:
                StartCoroutine(cameraHandler.Rotate(Vector3.up));
            break;


            case (int)Axis.CenterLeft:
                StartCoroutine(cameraHandler.Rotate(-Vector3.forward));
            break;
            case (int)Axis.CenterRight:
                StartCoroutine(cameraHandler.Rotate(Vector3.forward));
            break;
        }
    }
}
