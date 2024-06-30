using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite Cleaner;
    public Sprite Mop;
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
           /* case Rectangle s when (s.Length == s.Height):
                WriteLine($"{s.Length} x {s.Height} square");
                break;
            case Rectangle r:
                WriteLine($"{r.Length} x {r.Height} rectangle");
                break;
            default:
                WriteLine("<unknown shape>");
                break;*/
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
