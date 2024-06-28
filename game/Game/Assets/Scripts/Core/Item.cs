using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract String name { get; } 
    public String Name => name;

    [SerializeField] protected GameObject _containerLocation;
    protected Location _location;

    public abstract void use();

    protected void Start()
    {
        _location = _containerLocation.GetComponent<Location>();
    }
}
