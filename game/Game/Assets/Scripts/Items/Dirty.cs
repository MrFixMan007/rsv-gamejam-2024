using UnityEngine;

public abstract class Dirty : MonoBehaviour
{
    public float LowerBoundSpeedOfPollution = 5;
    public float UpperBoundSpeedOfPollution = 20;
    public float LowerBoundCountOfCharges = 5;
    public float UpperBoundCountOfCharges = 10;
    [SerializeField] protected float countOfCharges;
    [SerializeField] protected float speedOfPollution;
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

        speedOfPollution = Random.Range(LowerBoundSpeedOfPollution, UpperBoundSpeedOfPollution);
        countOfCharges = Random.Range(LowerBoundCountOfCharges, UpperBoundCountOfCharges);
    }

    public float GetDirtyForce()
    {
        return spriteOpacity.GetStepOfPollution();
    }

    protected void FixedUpdate()
    {
        if (countOfCharges > 0 && !spriteOpacity.IsFullDirty())
        {
            step += Time.fixedDeltaTime;
            if (step >= speedOfPollution)
            {
                step = 0;
                spriteOpacity.PlusTransparent();
                gameManager.NotifyAboutDirting(this);
            }
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