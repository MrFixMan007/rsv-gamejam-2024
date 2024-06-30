using UnityEngine;

public class ItemSourceOfWater : Item
{
    public override void Use()
    {
        // if(location) location.Clear();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        player.ItemCanInteract = this;
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        player.ItemCanInteract = null;
    }
}