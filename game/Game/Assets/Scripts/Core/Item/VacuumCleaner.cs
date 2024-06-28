
using System;
using UnityEngine;

public class VacuumCleaner : Item
{
    protected override string name
    {
        get => "Пылесос";
    }

    private void Update()
    {
        use();
    }

    public override void use()
    {
        if(_location != null) _location.clear();
    }
}