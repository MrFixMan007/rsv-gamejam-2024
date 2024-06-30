using UnityEngine;

public class Dusk : Dirty
{
    public override void Clean()
    {
        if (spriteOpacity.IsFullDirty())
        {
            if (player.Inventory.Item is ItemWetVacuumCleaner or ItemCleaningAgent)
            {
                gameManager.NotifyAboutCleaning(this);
                spriteOpacity.MakeTransparent();
            }
            else Debug.Log("Нужен инструмент помощнее!!!!");
        }
        else if (player.Inventory.Item is ItemVacuumCleaner or ItemWetVacuumCleaner)
        {
            gameManager.NotifyAboutCleaning(this);
            spriteOpacity.MakeTransparent();
        }
    }
}
