public class ItemMeat : Item, Pickable
{
    public override void Use()
    {
        if (player.ItemCanInteract is Cooking cooking)
        {
            cooking.Use();
        }
    }
}
