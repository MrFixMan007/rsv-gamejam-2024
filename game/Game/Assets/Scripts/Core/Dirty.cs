using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Dirty : MonoBehaviour
{
    public float speedOfPollution = 5;
    private float _step;
    private SpriteOpacity _spriteOpacity;
    
    [SerializeField] protected GameObject containerLocation;
    private Location _location;

    protected void Start()
    {
        _spriteOpacity = GetComponentInChildren<SpriteOpacity>();
        Debug.Log(_spriteOpacity);
        _location = containerLocation.GetComponent<Location>();
    }

    private void FixedUpdate()
    {
        _step += Time.fixedDeltaTime;
        if (_step >= speedOfPollution)
        {
            _step = 0;
            _spriteOpacity.plusTransparent();
            Debug.Log("Стало грязнее");
        }
    }
}
