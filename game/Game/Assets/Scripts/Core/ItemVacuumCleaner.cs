
using System;
using UnityEngine;

public class ItemVacuumCleaner : Item
{
    protected override bool canPickUp
    {
        get => true;
    }

    public override void use()
    {
        if(_location != null) _location.clear();
    }
}