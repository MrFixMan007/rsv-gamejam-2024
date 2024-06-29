using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory_UI _inventoryUI;
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject prefabItemVacuumCleaner;
    private GameObject _parentObject;

    public bool isGamePaused;

    public void SpawnPickablePrefab(Pickable item, Vector3 newItemCoordinates)
    {
        Debug.Log(item);
        switch (item)
        {
            case ItemVacuumCleaner:
                Instantiate(prefabItemVacuumCleaner, newItemCoordinates, Quaternion.identity, _parentObject.transform);
                break;
        }
    }

    public void ReturnObject(GameObject gameObjectToReturn, Vector3 coordinates)
    {
        gameObjectToReturn.transform.position = coordinates;
        gameObjectToReturn.SetActive(true);
    }

    public void DestroyObject(GameObject gameObjectDestroy)
    {
        gameObjectDestroy.SetActive(false);
        gameObjectDestroy.transform.position = Vector3.zero;
    }

    public void changePickedItemUI(Item item)
    {
        _inventoryUI.change_picked_item(item);
    }
    public void changePickedItemUIEmpty()
    {
        _inventoryUI.empty_picked_item();
    }

    private void Start()
    {
        _inventoryUI = GameObject.FindGameObjectWithTag("UI_Inventory").GetComponent<Inventory_UI>();
        _parentObject = GameObject.FindGameObjectWithTag("Location");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняет объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // Удаляет дублирующийся объект
        }
    }

    // Пример метода для паузы игры
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f; // Останавливает время в игре
        Debug.Log("Game Paused");
    }

    // Пример метода для продолжения игры
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f; // Восстанавливает время в игре
        Debug.Log("Game Resumed");
    }
}