using UnityEngine;

public class Dirty : MonoBehaviour
{
    public float speedOfPollution = 5;
    private float _step;
    private SpriteOpacity _spriteOpacity;
    private GameObject _player;
    
    [SerializeField] protected GameObject containerLocation;
    private Location _location;

    protected void Start()
    {
        _spriteOpacity = GetComponentInChildren<SpriteOpacity>();
        Debug.Log(_spriteOpacity);
        _location = containerLocation.GetComponent<Location>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        _step += Time.fixedDeltaTime;
        if (_step >= speedOfPollution)
        {
            _step = 0;
            _spriteOpacity.PlusTransparent();
            Debug.Log("Стало грязнее");
        }
    }

    public void Clean()
    {
        if (_player.GetComponent<Inventory>().Item is ItemVacuumCleaner)
        {
            _spriteOpacity.MakeTransparent();
        }
    }
}