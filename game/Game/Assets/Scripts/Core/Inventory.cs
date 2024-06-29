using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Pickable _item;
    
    public void DiscardItem(Vector3 newItemCoordinates)
    {
        GameManager.Instance.SpawnPickablePrefab(_item, newItemCoordinates);
        _item = null;
    }
    
    public void PickUpItem(Pickable newItem)
    {
        _item = newItem;
    }

    public bool IsEmpty() => _item == null;

    public void Use()
    {
        if (_item == null)
        {
            
        }
        
        switch (_item)
        {
            case ItemVacuumCleaner item:
                item.Use();
                break;
        }
    }
}