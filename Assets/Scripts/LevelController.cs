using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public Vector3 GridSize;

    public Vector3 maxEdges;
    public Vector3 minEdges;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        CalculateGridEdges();
    }

    private void CalculateGridEdges()
    {
        maxEdges = new Vector3(Mathf.Round(GridSize.x / 2), Mathf.Round(GridSize.y / 2), Mathf.Round(GridSize.z / 2));
        minEdges = new Vector3(Mathf.Round((GridSize.x / 2) * -1), Mathf.Round((GridSize.y / 2) * -1), Mathf.Round((GridSize.z / 2) * -1));
    }
}
