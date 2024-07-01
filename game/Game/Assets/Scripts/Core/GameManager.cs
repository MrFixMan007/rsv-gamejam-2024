using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory_UI _inventoryUI;
    public static GameManager Instance { get; private set; }
    private GameObject _parentObject;
    private float _countOfDusk;
    private float _countOfMuck;
    private float _countOfPuddle;
    [SerializeField] private float _countOfDirtyCanHoldToWin = 3;

    [SerializeField] private float _timeOfGame = 20;
    public bool isGamePaused;
    private float _step;

    public void NotifyAboutDirting(Dirty dirty)
    {
        switch (dirty)
        {
            case Dusk dusk:
                _countOfDusk += 1;
                Debug.Log("Пыли " + _countOfDusk);
                break;
            case Muck muck:
                _countOfMuck += 1;
                Debug.Log("Грязи " + _countOfMuck);
                break;
            case Puddle puddle:
                _countOfPuddle += 1;
                Debug.Log("Луж " + _countOfPuddle);
                break;
        }
    }
    
    public void NotifyAboutCleaning(Dirty dirty)
    {
        switch (dirty)
        {
            case Dusk dusk:
                _countOfDusk -= 1;
                Debug.Log("Пыли осталось " + _countOfDusk);
                break;
            case Muck muck:
                _countOfMuck -= 1;
                Debug.Log("Грязи осталось " + _countOfMuck);
                break;
            case Puddle puddle:
                _countOfPuddle -= 1;
                Debug.Log("Луж осталось " + _countOfPuddle);
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
        gameObjectDestroy.transform.position = new Vector3(10, 10);
    }

    public void ChangePickedItemUI(Item item)
    {
        _inventoryUI.change_picked_item(item);
    }
    public void ChangePickedItemUIEmpty()
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
            // DontDestroyOnLoad(gameObject); // Сохраняет объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // Удаляет дублирующийся объект
        }
    }

    private void FixedUpdate()
    {
        _step += Time.fixedDeltaTime;
        if (_step >= _timeOfGame)
        {
            Debug.Log("Счёт: " + _countOfDusk + _countOfMuck + _countOfPuddle);
            if (_countOfDusk + _countOfMuck + _countOfPuddle > _countOfDirtyCanHoldToWin)
            {
                Debug.Log("Вы проиграли!");
            }
            else Debug.Log("Вы выигралиииии!");
            PauseGame();
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