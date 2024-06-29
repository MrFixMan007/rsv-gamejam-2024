using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField] public LocationType locationType;
    
    public void Clear()
    {
        Debug.Log("Чисто!");
    }
    
    public enum LocationType
    {
        LivingRoom,
        ChildRoom,
        Bathroom,
        Hallway,
        Bedroom,
        Kitchen
    }
}
