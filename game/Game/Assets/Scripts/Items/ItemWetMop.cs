using UnityEngine;
using UnityEngine.Serialization;

public class ItemWetMop : Item, Pickable
{
    private Dirty _dirty;
    private GameObject _dirtyCanClear;
    [SerializeField] private int _maxCountOfCharges = 10;
    [SerializeField] private int _countOfCharges = 0;
    
    [SerializeField] protected Sprite spriteWithWaterReadyForUse;
    [SerializeField] protected Sprite spriteWithWater;

    public override void Use()
    {
        if (_dirty is Muck && _countOfCharges > 0)
        {
            _dirty.Clean();
            _countOfCharges -= 1;
            if (_countOfCharges <= 0)
            {
                spriteRenderer.sprite = spriteGeneral;
                GameManager.Instance.ChangePickedItemUI(this);
            }
        }
        if (player.ItemCanInteract is ItemSourceOfWater)
        {
            ResetCount();
        }
    }

    private void ResetCount()
    {
        _countOfCharges = _maxCountOfCharges;
        spriteRenderer.sprite = spriteWithWater;
        GameManager.Instance.ChangePickedItemUI(this);
    }

    public void PutDirtyCanClear(Dirty dirty)
    {
        _dirty = dirty;
    }

    public bool IsEmpty()
    {
        return _countOfCharges <= 0;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && spriteReadyForUse != null)
        {
            if (_countOfCharges > 0)
            {
                spriteRenderer.sprite = spriteWithWaterReadyForUse;
            }
            else
            {
                spriteRenderer.sprite = spriteReadyForUse;
            }
            player.SetNewItemCanPickup(gameObject);
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && spriteReadyForUse != null)
        {
            if (_countOfCharges > 0)
            {
                spriteRenderer.sprite = spriteWithWater;
            }
            else
            {
                spriteRenderer.sprite = spriteGeneral;
            }
            player.SetCantPickup();
        }
    }
}