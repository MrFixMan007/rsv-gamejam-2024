using UnityEngine;

public class Player : MonoBehaviour
{
    public Clothes Clothes;
    private readonly Inventory _inventory = new Inventory();
    
    public void DiscardItem(Vector3 discardedItemCoordinates)
    {
        if (!_inventory.IsEmpty()) _inventory.DiscardItem(discardedItemCoordinates);
    }

    public void Interact()
    {
        _inventory.Use();
    }

    public void SetNewItemCanPickup(GameObject newItemCanPickup)
    {
        _inventory.NewItemCanPickup = newItemCanPickup;
    }
    
    public void SetCantPickup()
    {
        _inventory.NewItemCanPickup = null;
    }
}