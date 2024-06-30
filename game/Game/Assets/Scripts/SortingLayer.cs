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
    
    // Start is called before the first frame update
    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        
        Transform[] allChildren = _playerObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(tagToFind))
            {
                Debug.Log(child);
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
                Debug.Log(child);
                _foundationObject = child.gameObject;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_foundationPlayerObject.transform.position.y > _foundationObject.transform.position.y)
        {
            Debug.Log("Игрок за стеной");
            _tilemapRenderer.sortingLayerName = "UpperPlayer";
        }
        else
        {
            Debug.Log("Игрок перед стеной");
            _tilemapRenderer.sortingLayerName = "UnderPlayer";
        }
    }
}
