using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract String name { get; } 
    public String Name => name;
    public Location.LocationType LocationType;
    protected Location _location;

    public abstract void use();

    protected void Start()
    {
        Location[] locations = FindObjectsOfType<Location>();
        
        foreach (var loc in locations)
        {
            if (loc.locationType == LocationType)
            {
                _location = loc;
                Debug.Log(_location);
                break;
            }
        }
    }
}
