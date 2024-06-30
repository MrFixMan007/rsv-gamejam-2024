using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true; // Заморозить вращение
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        // _animator.SetFloat("Horizontal", _movement.x);

        _animator.SetBool("IsHorizontal", _movement.x != 0);
        
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.normalized.sqrMagnitude);
        
        if (_movement.x < 0)
        {
            // Движение влево
            _spriteRenderer.flipX = true;
        }
        else if (_movement.x > 0)
        {
            // Движение вправо
            _spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
