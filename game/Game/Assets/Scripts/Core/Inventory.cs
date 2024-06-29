using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Pickable _item;
    private GameObject _itemObject;
    public GameObject NewItemCanPickup;

    public Pickable Item => _item;

    public void DiscardItem(Vector3 newItemCoordinates)
    {
        GameManager.Instance.ReturnObject(_itemObject, newItemCoordinates);
        GameManager.Instance.changePickedItemUIEmpty();
        _item = null;
        _itemObject = null;
    }

    private void PickUpItem(Pickable newItem)
    {
        _itemObject = NewItemCanPickup;
        GameManager.Instance.DestroyObject(NewItemCanPickup);
        GameManager.Instance.changePickedItemUI((Item)newItem);
        _item = newItem;
    }

    public bool IsEmpty() => _item == null;

    public void Use()
    {
        if (_item == null)
        {
            if (NewItemCanPickup != null)
            {
                PickUpItem(NewItemCanPickup.GetComponent<Pickable>());
            }
        }
        
        switch (_item)
        {
            case ItemVacuumCleaner item:
                item.Use();
                break;
        }
    }
}