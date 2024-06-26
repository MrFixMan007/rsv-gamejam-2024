using UnityEngine;

public class ItemCleaningAgent : Item, Pickable
{
    private Dirty _dirty;
    private GameObject _dirtyCanClear;
    
    public override void Use()
    {
        if (_dirty is Puddle) _dirty.Clean();
        // if(location) location.Clear();
    }

    public void PutDirtyCanClear(Dirty dirty)
    {
        _dirty = dirty;
    }

    public Sprite SpriteReadyToUse { get; }
}