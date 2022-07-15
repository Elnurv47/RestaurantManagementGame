using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public interface IGrid
    {
        int Width { get; }
        int Length { get; }
        Vector3 GetNodePosition(GridIndex point);
        Vector3 GetNodeCenter(GridIndex point);
        Vector3 GetNodeCenter(Vector3 worldPosition);
        Node GetNode(Vector3 cellWorldPosition);
        void SetNode(Vector3 cellWorldPosition, Node gridObject);
        TextMesh[,] GetDebugArray();
        void SetActive(bool active);
        List<Node> GetNodesInsideArea(Vector3 center, Vector3 halfExtents, LayerMask ignoreLayerMask);
        Vector3 GetGridCenterPosition();
        List<Node> GetNodes();
    }
}