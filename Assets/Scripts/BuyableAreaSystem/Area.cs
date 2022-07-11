using GridSystem;
using UnityEngine;
using System.Collections.Generic;

public class Area : MonoBehaviour
{
    private GridXZ _gridXZ;
    private List<Node> _nodes;

    public void Init(GridXZ grid)
    {
        _gridXZ = grid;

        _nodes = _gridXZ.GetNodesInsideArea(center: transform.position, halfExtents: transform.localScale / 2, LayerMask.NameToLayer("Area"));

        foreach (Node node in _nodes)
        {
            node.SetUsable(true);
        }
    }

    public void Scale(Vector3 scaleVector)
    {
        transform.localScale = scaleVector;
    }
}
