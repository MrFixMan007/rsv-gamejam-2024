
using System;
using UnityEngine;

public class ItemVacuumCleaner : Item
{
    protected override string name
    {
        get => "Пылесос";
    }

    public override void use()
    {
        if(_location != null) _location.clear();
    }
}