using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Clothes clothes;
    public Inventory inventory = new Inventory();
    
    // public void pickUpItem(GameObject gameObjectItem)
    // {
    //     Pickable item = gameObjectItem.GetComponent<Pickable>();
    //     if (inventory.IsEmpty())
    //     {
    //         inventory.DiscardItem(gameObjectItem.transform.position);
    //     }
    //     inventory.PickUpItem(item);
    //     // gameObjectItem.GetComponent<>().setChangeUISlot(item);
    //     Destroy(gameObjectItem);
    // }

    public void DiscardItem(Vector3 discardedItemCoordinates)
    {
        if (!inventory.IsEmpty()) inventory.DiscardItem(discardedItemCoordinates);
    }

    public void Interact()
    {
        inventory.Use();
    }

    public void SetNewItemCanPickup(GameObject newItemCanPickup)
    {
        inventory.NewItemCanPickup = newItemCanPickup;
    }
    
    public void SetCantPickup()
    {
        inventory.NewItemCanPickup = null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}