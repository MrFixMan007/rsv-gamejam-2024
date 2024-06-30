using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingLayer : MonoBehaviour
{
    private GameObject _playerObject;
    private TilemapRenderer _tilemapRenderer;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private string tagToFind = "Foundation";
    private GameObject _foundationObject;
    private GameObject _foundationPlayerObject;

    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");

        Transform[] allChildren = _playerObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(tagToFind))
            {
                _foundationPlayerObject = child.gameObject;
                break;
            }
        }

        _tilemapRenderer = GetComponent<TilemapRenderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_tilemapRenderer || _spriteRenderer)
        {
            allChildren = GetComponentsInChildren<Transform>();

            foreach (Transform child in allChildren)
            {
                if (child.CompareTag(tagToFind))
                {
                    _foundationObject = child.gameObject;
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (_tilemapRenderer)
        {
            // игрок за
            if (_foundationPlayerObject.transform.position.y > _foundationObject.transform.position.y)
            {
                _tilemapRenderer.sortingLayerName = "UpperPlayer";
            }
            // игрок перед
            else
            {
                _tilemapRenderer.sortingLayerName = "UnderPlayer";
            }
        }
        else if (_spriteRenderer)
        {
            // игрок за
            if (_foundationPlayerObject.transform.position.y > _foundationObject.transform.position.y)
            {
                _spriteRenderer.sortingLayerName = "UpperPlayer";
            }
            // игрок перед
            else
            {
                _spriteRenderer.sortingLayerName = "UnderPlayer";
            }
        }
    }
}
