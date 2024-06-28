using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField] public LocationType locationType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clear()
    {
        Debug.Log("Чиста!!!");
    }
    
    public enum LocationType
    {
        ChildRoom,
        BathRoom
    }
}
