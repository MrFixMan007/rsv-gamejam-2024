using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected GameObject containerLocation;
    protected Location location;
    protected GameObject playerObject;
    protected Player player;
    [SerializeField] protected Sprite spriteReadyForUse;
    protected Sprite spriteGeneral;
    protected SpriteRenderer spriteRenderer;

    public abstract void Use();

    protected virtual void Start()
    {
        if ( containerLocation != null) location = containerLocation.GetComponent<Location>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        
        spriteGeneral = GetComponent<SpriteRenderer>().sprite;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && spriteReadyForUse != null)
        {
            spriteRenderer.sprite = spriteReadyForUse;
            player.SetNewItemCanPickup(gameObject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && spriteReadyForUse != null)
        {
            spriteRenderer.sprite = spriteGeneral;
            player.SetCantPickup();
        }
    }
}