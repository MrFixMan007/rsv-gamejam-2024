using UnityEngine;

public abstract class Dirty : MonoBehaviour
{
    public float LowerBoundSpeedOfPollution = 5;
    public float UpperBoundSpeedOfPollution = 50;
    private float _speedOfPollution;
    protected float step;
    protected SpriteOpacity spriteOpacity;
    protected GameObject playerObject;
    protected Player player;
    
    [SerializeField] protected GameObject containerLocation;
    protected Location _location;
    protected GameManager gameManager;
    
    [SerializeField] protected Sprite spriteReadyForUse;
    protected Sprite spriteGeneral;
    protected SpriteRenderer spriteRenderer;
    
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
        
        spriteGeneral = GetComponent<SpriteRenderer>().sprite;
        spriteRenderer = GetComponent<SpriteRenderer>();

        _speedOfPollution = Random.Range(LowerBoundSpeedOfPollution, UpperBoundSpeedOfPollution);
    }

    public float GetDirtyForce()
    {
        return spriteOpacity.GetStepOfPollution();
    }

    protected void FixedUpdate()
    {
        step += Time.fixedDeltaTime;
        if (step >= _speedOfPollution)
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
            spriteRenderer.sprite = spriteReadyForUse;
            player.SetDirtyCanClear(gameObject);
        }
    }
    
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.sprite = spriteGeneral;
            player.SetNoDirty();
        }
    }
}