using System;
using UnityEngine;

public class Dirty : MonoBehaviour
{
    public String name;
    public float speedOfPollution = 5;
    private float step;
    private SpriteOpacity _spriteOpacity;
    
    [SerializeField] protected GameObject _containerLocation;
    private Location _location;

    protected void Start()
    {
        _spriteOpacity = GetComponentInChildren<SpriteOpacity>();
        Debug.Log(_spriteOpacity);
        _location = _containerLocation.GetComponent<Location>();
    }

    private void FixedUpdate()
    {
        step += Time.fixedDeltaTime;
        if (step >= speedOfPollution)
        {
            step = 0;
            _spriteOpacity.plusTransparent();
            Debug.Log("Стало грязнее");
        }
    }
}
