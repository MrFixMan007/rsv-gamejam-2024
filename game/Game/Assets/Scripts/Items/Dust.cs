using UnityEngine;

public class Dust : Dirty
{
    public override void Clean()
    {
        if (_spriteOpacity.IsFullDirty())
        {
            if (_player.Inventory.Item is ItemWetVacuumCleaner)
            {
                _spriteOpacity.MakeTransparent();
            }
            else if (_player.Inventory.Item is ItemCleaningAgent)
            {
                _spriteOpacity.ChangeTransparent(0.5f);
            }
            else Debug.Log("Нужен инструмент помощнее!!!!");
        }
        else if (_player.Inventory.Item is ItemVacuumCleaner or ItemWetVacuumCleaner)
        {
            _spriteOpacity.MakeTransparent();
        }
    }
}
