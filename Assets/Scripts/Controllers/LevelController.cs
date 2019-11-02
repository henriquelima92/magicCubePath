using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public Vector3Int GridSize;
    public Vector3 Gravity = new Vector3(0f, -9.81f,0);

    public List<BigNode> BigNodes;
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

        BigNodes = new List<BigNode>();
    }
}
