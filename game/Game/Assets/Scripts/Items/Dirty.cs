using UnityEngine;

public abstract class Dirty : MonoBehaviour
{
    public float speedOfPollution = 5;
    protected float _step;
    protected SpriteOpacity _spriteOpacity;
    protected GameObject _playerObject;
    protected Player _player;
    
    [SerializeField] protected GameObject containerLocation;
    protected Location _location;
    
    public abstract void Clean();

    protected void Start()
    {
        _spriteOpacity = GetComponentInChildren<SpriteOpacity>();
        Debug.Log(_spriteOpacity);
        if (containerLocation)
        {
            _location = containerLocation.GetComponent<Location>();
        }
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _player = _playerObject.GetComponent<Player>();
    }

    protected void FixedUpdate()
    {
        _step += Time.fixedDeltaTime;
        if (_step >= speedOfPollution)
        {
            _step = 0;
            _spriteOpacity.PlusTransparent();
            Debug.Log("Стало грязнее");
        }
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Я мусор!");
            _player.SetDirtyCanClear(gameObject);
        }
    }
    
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("из мусора игрок Вышел");
            _player.SetNoDirty();
        }
    }
}