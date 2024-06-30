using UnityEngine;

public class ItemCleaningAgent : Item, Pickable
{
    private Dirty _dirty;
    private GameObject _dirtyCanClear;
    
    public override void Use()
    {
        if (_dirty) _dirty.Clean();
        // if(location) location.Clear();
    }

    public void PutDirtyCanClear(Dirty dirty)
    {
        _dirty = dirty;
    }
}