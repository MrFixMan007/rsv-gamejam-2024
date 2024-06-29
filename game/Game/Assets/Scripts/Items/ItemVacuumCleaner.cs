public class ItemVacuumCleaner : Item, Pickable
{
    public override void Use()
    {
        if(location) location.Clear();
    }
}