public class Muck : Dirty
{
    public override void Clean()
    {
        if (player.Inventory.Item is ItemWetMop)
        {
            gameManager.NotifyAboutCleaning(this);
            spriteOpacity.MakeTransparent();
        }
    }
}
