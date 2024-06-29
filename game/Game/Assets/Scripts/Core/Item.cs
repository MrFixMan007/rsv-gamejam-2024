using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected GameObject containerLocation;
    protected Location location;

    public abstract void Use();

    protected void Start()
    {
        if ( containerLocation != null) location = containerLocation.GetComponent<Location>();
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