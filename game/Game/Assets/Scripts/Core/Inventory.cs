using UnityEngine;

public class Inventory
{
    private Pickable _item;
    private GameObject _itemObjectPicked;
    public GameObject NewItemCanPickup;
    
    private Dirty _dirty;
    private GameObject _dirtyCanClear;
    public Pickable Item => _item;

    public void DiscardItem(Vector3 newItemCoordinates)
    {
        GameManager.Instance.ReturnObject(_itemObjectPicked, newItemCoordinates);
        GameManager.Instance.ChangePickedItemUIEmpty();
        _item = null;
        _itemObjectPicked = null;
    }

    private void PickUpItem(Pickable newItem)
    {
        _itemObjectPicked = NewItemCanPickup;
        GameManager.Instance.DestroyObject(NewItemCanPickup);
        GameManager.Instance.ChangePickedItemUI((Item)newItem);
        _item = newItem;
    }

    public void SetDirtyCanClear(GameObject gameObjectDirty)
    {
        _dirtyCanClear = gameObjectDirty;
        _dirty = gameObjectDirty.GetComponent<Dirty>();
    }

    public void SetNoDirty()
    {
        _dirtyCanClear = null;
        _dirty = null;
    }

    public bool IsEmpty() => _item == null;

    public void Use()
    {
        if (_item == null)
        {
            if (NewItemCanPickup)
            {
                PickUpItem(NewItemCanPickup.GetComponent<Pickable>());
            }
        }
        
        switch (_item)
        {
            case ItemVacuumCleaner item:
                item.PutDirtyCanClear(_dirty);
                item.Use();
                break;
            case ItemWetVacuumCleaner item:
                item.PutDirtyCanClear(_dirty);
                item.Use();
                break;
            case ItemCleaningAgent item:
                item.PutDirtyCanClear(_dirty);
                item.Use();
                break;
            case ItemWetMop item:
                item.PutDirtyCanClear(_dirty);
                item.Use();
                break;
        }
    }
}