using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Item item;
    
    public void discardItem(Vector3 newItemCoordinates)
    {
        GameManager.Instance.SpawnItemPrefab(item, newItemCoordinates);
    }
    
    public void pickUpItem(Item newItem)
    {
        item = newItem;
    }
}
