using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapTile
{
    None,
    NormalWall,
    TouchWall,
    SpikeWall,
    ArrowWall,
    Spring,
    TeleportStartPoint,
    TeleportEndPoint,
}


[System.Serializable]
public class Node
{
    public MapTile mapTile;
    public int x;
    public int y;

    public Node(MapTile mapTile,int x,int y)
    {
        this.mapTile = mapTile;
        this.x = x;
        this.y = y;
    }

    public bool EqaulPosition(int x,int y)
    {
        return this.x == x && this.y == y;
    }
}

public class Tile : MonoBehaviour
{
    public List<Node> nodes = new List<Node>();

    public GameObject noneObject;
    public GameObject normalWallObject;
    public GameObject touchWallObject;
    public GameObject spikeWallObject;
    public GameObject arrowWallObject;
    public GameObject springObject;
    public GameObject teleportStartPointObject;
    public GameObject teleportEndPointObject;

    public Transform nodesParent;


    #region 타일 관련
    //타일 반환
    public Node GetTile(int x,int y)
    {
        foreach(var node in nodes)
        {
            if(node.EqaulPosition(x,y))
            {
                return node;
            }
        }
        return null;
    }

    //타일 추가
    public void SetTile(Node node)
    {
        nodes.Add(node);
        GameObject obj;
        switch (node.mapTile)
        {
            case MapTile.None:
                obj = Instantiate(noneObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.NormalWall:
                obj = Instantiate(normalWallObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.TouchWall:
                obj = Instantiate(touchWallObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.SpikeWall:
                obj = Instantiate(spikeWallObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.ArrowWall:
                obj = Instantiate(arrowWallObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.Spring:
                obj = Instantiate(springObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.TeleportStartPoint:
                obj = Instantiate(teleportStartPointObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            case MapTile.TeleportEndPoint:
                obj = Instantiate(teleportEndPointObject, new Vector3(node.x, node.y, 0), Quaternion.identity);
                break;
            default:
                obj = null;
                break;
        }

        if(obj != null)
        {
            obj.transform.parent = nodesParent;
        }
    }

    //타일 상태 변경
    public void ChangeTile(Node updateNode)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].EqaulPosition(updateNode.x, updateNode.y))
            {
                nodes[i] = updateNode;
            }
        }
    }
    #endregion
}
