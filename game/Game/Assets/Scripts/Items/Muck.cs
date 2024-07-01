public class Muck : Dirty
{
    public override void Clean()
    {
        if (player.Inventory.Item is ItemWetMop or ItemWetVacuumCleaner)
        {
            gameManager.NotifyAboutCleaning(this);
            spriteOpacity.MakeTransparent();
            speedOfPollution += 1;
            countOfCharges -= 1;
        }
    }
}
