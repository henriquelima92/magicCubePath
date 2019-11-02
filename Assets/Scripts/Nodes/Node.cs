using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector3 Position;

    public Color Color { get => color; }
    private Color color;

    public bool Enabled { get => enabled; }
    private bool enabled;

    public bool IsOccupied { get => objectInPosition; }
    private bool isOccupied;

    public Transform ObjectInPosition { get => objectInPosition; }
    private Transform objectInPosition;

    public Node(Vector3 position, Color color)
    {
        this.Position = position;
        this.color = color;

        isOccupied = false;
        enabled = true;

        objectInPosition = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        objectInPosition.position = position;
        objectInPosition.GetComponent<Renderer>().material.color = color;
    }

    public void SetColor(Color color)
    {
        this.color = color;
        objectInPosition.GetComponent<Renderer>().material.color = color;
    }

    public void SetEnabled(bool isEnabled)
    {
        this.enabled = isEnabled;
    }

    public void SetOccupied(Transform objectInPosition)
    {
        if(objectInPosition == null)
        {
            isOccupied = false;
            objectInPosition = null;
        }
        else
        {
            isOccupied = true;
            this.objectInPosition = objectInPosition;
        }
    }
}
