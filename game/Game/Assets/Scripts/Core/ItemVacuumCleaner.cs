public class ItemVacuumCleaner : Item, Pickable
{
    public override void Use()
    {
        if(location != null) location.clear();
    }
}