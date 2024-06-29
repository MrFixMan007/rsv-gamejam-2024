using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract Boolean canPickUp { get; }

    [SerializeField] protected GameObject _containerLocation;
    protected Location _location;

    public abstract void use();

    protected void Start()
    {
        _location = _containerLocation.GetComponent<Location>();
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
        }
    }
}
