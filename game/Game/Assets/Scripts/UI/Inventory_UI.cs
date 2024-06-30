using UnityEngine;
using UnityEngine.U2D;

public class Inventory_UI : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite Cleaner;
    public Sprite Cleaner_pro;
    public Sprite Mop_empty;
    public Sprite Mop_wet;
    public Sprite Agent;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void change_picked_item(Item item) 
    {
        spriteRenderer.enabled = true;
        switch (item)
        {
            case ItemVacuumCleaner VC:
                spriteRenderer.sprite = Cleaner;
                break;
            case ItemCleaningAgent CA:
                spriteRenderer.sprite = Agent;
                break;
            case ItemWetMop WM:
                spriteRenderer.sprite = WM.IsEmpty() ? Mop_empty : Mop_wet;
                break;
            case ItemWetVacuumCleaner VCP:
                spriteRenderer.sprite = Cleaner_pro;
                break;
            case null:
                empty_picked_item();
                break;
            default:break;
        }
    }
    public void empty_picked_item()
    {
        spriteRenderer.enabled = false;
    }
}
