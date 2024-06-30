using UnityEngine;

public abstract class Dirty : MonoBehaviour
{
    public float speedOfPollution = 5;
    protected float step;
    protected SpriteOpacity spriteOpacity;
    protected GameObject playerObject;
    protected Player player;
    
    [SerializeField] protected GameObject containerLocation;
    protected Location _location;
    protected GameManager gameManager;
    
    public abstract void Clean();

    protected void Start()
    {
        spriteOpacity = GetComponentInChildren<SpriteOpacity>();
        if (containerLocation)
        {
            _location = containerLocation.GetComponent<Location>();
        }
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        gameManager = GameManager.Instance;
    }

    public float GetDirtyForce()
    {
        return spriteOpacity.GetSpriteAlpha();
    }

    protected void FixedUpdate()
    {
        step += Time.fixedDeltaTime;
        if (step >= speedOfPollution)
        {
            step = 0;
            spriteOpacity.PlusTransparent();
            gameManager.NotifyAboutDirting(this);
        }
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SetDirtyCanClear(gameObject);
        }
    }
    
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SetNoDirty();
        }
    }
}