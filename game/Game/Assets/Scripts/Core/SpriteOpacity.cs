using UnityEngine;

public class SpriteOpacity : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float stepOfPollution = 0.1f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        MakeTransparent();
    }

    public void MakeTransparent()
    {
        ChangeTransparent(0f);
    }
    
    public void MakeNonTransparent()
    {
        ChangeTransparent(1f);
    }

    private void ChangeTransparent(float newAlpha)
    {
        if (_spriteRenderer != null)
        {
            Color newColor = _spriteRenderer.color;
            newColor.a = newAlpha;
            _spriteRenderer.color = newColor;
        }
    }

    public void PlusTransparent()
    {
        if (_spriteRenderer)
        {
            Color newColor = _spriteRenderer.color;
            if ( newColor.a + stepOfPollution < 1f) newColor.a += stepOfPollution;
            else newColor.a = 1;
            _spriteRenderer.color = newColor;
        }
    }
}
