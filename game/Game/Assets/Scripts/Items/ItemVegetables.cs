using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVegetables : Item, Pickable
{
    public override void Use()
    {
        if (player.ItemCanInteract is Cooking cooking)
        {
            cooking.Use();
        }
    }
}
