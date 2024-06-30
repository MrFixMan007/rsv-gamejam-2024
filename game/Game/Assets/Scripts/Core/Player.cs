using UnityEngine;

public class Player : MonoBehaviour
{
    public Clothes Clothes;
    public readonly Inventory Inventory = new Inventory();
    public Item ItemCanInteract;
    
    public void DiscardItem(Vector3 discardedItemCoordinates)
    {
        if (!Inventory.IsEmpty()) Inventory.DiscardItem(discardedItemCoordinates);
    }

    public void Interact()
    {
        Inventory.Use();
    }

    public void SetNewItemCanPickup(GameObject newItemCanPickup)
    {
        Inventory.NewItemCanPickup = newItemCanPickup;
    }
    
    public void SetCantPickup()
    {
        Inventory.NewItemCanPickup = null;
    }
    
    public void SetDirtyCanClear(GameObject dirtyObject)
    {
        Inventory.SetDirtyCanClear(dirtyObject);
    }

    public void SetNoDirty()
    {
        Inventory.SetNoDirty();
    }
}