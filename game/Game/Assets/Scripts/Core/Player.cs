using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Clothes clothes;
    public Inventory inventory;
    
    public void pickUpItem(GameObject gameObjectItem)
    {
        Pickable item = gameObjectItem.GetComponent<Pickable>();
        if (inventory.IsEmpty())
        {
            inventory.DiscardItem(gameObjectItem.transform.position);
        }
        inventory.PickUpItem(item);
        // gameObjectItem.GetComponent<>().setChangeUISlot(item);
        Destroy(gameObjectItem);
    }

    public void DiscardItem(Vector3 discardedItemCoordinates)
    {
        inventory.DiscardItem(discardedItemCoordinates);
    }

    private void useItem()
    {
        inventory.Use();
    }

    public void Interact()
    {
        if (inventory.IsEmpty())
        {
            Debug.Log("Посвистела");
        }
        inventory.Use();
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