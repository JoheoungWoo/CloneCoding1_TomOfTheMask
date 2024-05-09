using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapItem
{
    Dot,
    Gold,
    Star,
}

public interface IItem
{
    void Touch();
}

public class Dot : MonoBehaviour,IItem
{
    public void Touch()
    {
        
    }
}

public class Gold : MonoBehaviour, IItem
{
    public void Touch()
    {
        DataManager.Instance.gold += 10;
    }
}

public class Star : MonoBehaviour, IItem
{
    public void Touch()
    {

    }
}

public class Items : MonoBehaviour
{
    public Transform itemParent;

    public GameObject dotObject;
    public GameObject goldObject;
    public GameObject starObject;

    #region 아이템 관련
    public GameObject CreateItem(MapItem mapItem,int x, int y)
    {
        GameObject obj;
        switch(mapItem)
        {
            case MapItem.Dot:
                obj = Instantiate(dotObject, new Vector3(x, y, 0),Quaternion.identity);
                break;
            case MapItem.Gold:
                obj = Instantiate(goldObject, new Vector3(x, y, 0), Quaternion.identity);
                break;
            case MapItem.Star:
                obj = Instantiate(starObject, new Vector3(x, y, 0), Quaternion.identity);
                break;
            default:
                obj = null;
                break;
        }

        return obj;
    }
    #endregion
}
