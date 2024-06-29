using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected GameObject containerLocation;
    protected Location location;
    protected GameObject playerObject;
    protected Player player;

    public abstract void Use();

    protected virtual void Start()
    {
        if ( containerLocation != null) location = containerLocation.GetComponent<Location>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // protected void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Игрок Привет!");
    //     }
    // }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Игрок Привет!");
            
            player.SetNewItemCanPickup(gameObject);
        }
    }

    // protected void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Игрок Вышел(");
    //     }
    // }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Игрок Вышел(");
            player.SetCantPickup();
        }
    }
}