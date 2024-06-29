using UnityEngine;

public class ItemWetMop : Item, Pickable
{
    private Dirty _dirty;
    private GameObject _dirtyCanClear;
    [SerializeField] private int _maxCountOfCharges = 10;
    [SerializeField] private int _countOfCharges;

    protected override void Start()
    {
        base.Start();
        ResetCount();
    }

    public override void Use()
    {
        if (_dirty && _countOfCharges > 0)
        {
            _dirty.Clean();
            _countOfCharges -= 1;
        }
        // if(location) location.Clear();
        if (player.ItemCanInteract is ItemSourceOfWater)
        {
            ResetCount();
        }
    }

    private void ResetCount()
    {
        _countOfCharges = _maxCountOfCharges;
        Debug.Log("количество использований" + _countOfCharges);
    }

    public void PutDirtyCanClear(Dirty dirty)
    {
        _dirty = dirty;
    }
}