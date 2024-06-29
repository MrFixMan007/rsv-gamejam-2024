using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Clothes clothes;
    public Inventory inventory;
    
    public void pickUpItem(GameObject gameObjectItem)
    {
        Item item = gameObjectItem.GetComponent<Item>();
        if (inventory.item != null)
        {
            inventory.discardItem(gameObjectItem.transform.position);
        }
        inventory.pickUpItem(item);
        // gameObjectItem.GetComponent<>().setChangeUISlot(item);
        Destroy(gameObjectItem);
    }

    public void DiscardItem(Vector3 discardedItemCoordinates)
    {
        inventory.discardItem(discardedItemCoordinates);
    }

    private void useItem()
    {
        inventory.item.use();
    }

    public void Interact()
    {
        if (inventory.item == null)
        {
            Debug.Log("Посвистела");
        }
        switch (inventory.item)
        {
            case ItemVacuumCleaner:
                useItem();
                break;
        }
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
