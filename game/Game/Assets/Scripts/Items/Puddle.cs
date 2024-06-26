public class Puddle : Dirty
{
    public override void Clean()
    {
        if (player.Inventory.Item is ItemCleaningAgent)
        {
            gameManager.NotifyAboutCleaning(this);
            spriteOpacity.MakeTransparent();
            speedOfPollution += 1;
            countOfCharges -= 1;
        }
    }
}
