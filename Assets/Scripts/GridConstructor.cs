using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridConstructor : MonoBehaviour
{
    private Vector3Int gridSize;
    public Vector3 initPosition;

    private void Start()
    {
        this.gridSize = LevelController.Instance.GridSize;
        Build();
    }

    private void Build()
    {
        GameObject holder = new GameObject();
        List<BigNode> bigNodes = new List<BigNode>();

        for(int z = 0; z < gridSize.z; z++)
        {
            BigNode bigNode = new BigNode(gridSize.x, gridSize.y);

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    Vector3 position = initPosition + new Vector3(x, y, z);
                    Node block = new Node(position, Color.white);
                    bigNode.AddNode(x,y, block);
                }
            }

            bigNode.SetMiddlePoint(z);
            bigNodes.Add(bigNode);
        }

        Vector3 holderPosition = GameUtilities.GetMiddlePoint(bigNodes[0].Holder.transform.position, bigNodes[bigNodes.Count - 1].Holder.transform.position);
        holder.transform.position = holderPosition;

        for (int i = 0; i < bigNodes.Count; i++)
        {
            bigNodes[i].Holder.transform.SetParent(holder.transform);
        }

        LevelController.Instance.BigNodes = bigNodes;
        holder.transform.position = initPosition;
    }
}
