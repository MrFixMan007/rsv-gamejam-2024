using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Clothes clothes;
    public Inventory inventory;

    public void pickUpItem(Item newItem)
    {
        if (inventory.item != null)
        {
            discardItem();
        }
        inventory.item = newItem;
    }

    public void discardItem()
    {
        
    }

    public void useItem()
    {
        inventory.item.use();
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
