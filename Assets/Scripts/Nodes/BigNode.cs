using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BigNode
{
    public GameObject Holder { get => holder; }
    private GameObject holder;

    private int xLenght, yLenght;
    private Node[,] nodes;

    public List<Node> NodesList;

    public BigNode(int xLenght, int yLenght)
    {
        this.xLenght = xLenght;
        this.yLenght = yLenght;
        nodes = new Node[xLenght, yLenght];
        NodesList = new List<Node>();

        holder = new GameObject();
    }

    public void AddNode(int xPosition, int yPosition, Node node)
    {
        nodes[xPosition, yPosition] = node;
        NodesList.Add(node);
    }

    public void SetMiddlePoint(float zPosition)
    {
        float minPositionX = nodes[0, 0].Position.x;
        float maxPositionX = nodes[xLenght - 1, 0].Position.x;

        float minPositionY = nodes[0, 0].Position.y;
        float maxPositionY = nodes[0, yLenght - 1].Position.y;

        holder.transform.position = new Vector3(GameUtilities.GetMiddlePoint(minPositionX, maxPositionX), GameUtilities.GetMiddlePoint(minPositionY, maxPositionY), zPosition);
        SetNodesAsChild();
    }

    private void SetNodesAsChild()
    {
        for(int i=0; i<NodesList.Count; i++)
        {
            NodesList[i].ObjectInPosition.SetParent(holder.transform);
        }
    }
}
