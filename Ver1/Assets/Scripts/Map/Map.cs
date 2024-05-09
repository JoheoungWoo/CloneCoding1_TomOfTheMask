using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class Map : MonoBehaviour
{
    public List<Node> nodes;
    private Tile tile;

    public void Awake()
    {
        tile = GetComponent<Tile>();

        CreateMap(nodes);
    }

    public void CreateMap(List<Node> nodes)
    {
        foreach(var node in nodes)
        {
            tile.SetTile(new Node(node.mapTile, node.x, node.y));
        }
    }
}
