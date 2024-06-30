using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingLayer : MonoBehaviour
{
    private GameObject _playerObject;
    private TilemapRenderer _tilemapRenderer;
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

    void Update()
    {
        // игрок за стеной
        if (_foundationPlayerObject.transform.position.y > _foundationObject.transform.position.y)
        {
            _tilemapRenderer.sortingLayerName = "UpperPlayer";
        }
        // игрок перед стеной
        else
        {
            _tilemapRenderer.sortingLayerName = "UnderPlayer";
        }
    }
}
