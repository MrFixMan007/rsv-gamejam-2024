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
    [SerializeField] private float _countOfDirtyCanHoldToWin = 5;

    [SerializeField] private float _timeOfGame = 20;
    public bool isGamePaused;
    private float _step;

    public void NotifyAboutDirting(Dirty dirty)
    {
        switch (dirty)
        {
            case Dusk dusk:
                _countOfDusk += dusk.GetDirtyForce();
                break;
            case Muck muck:
                _countOfMuck += muck.GetDirtyForce();
                break;
            case Puddle puddle:
                _countOfPuddle += puddle.GetDirtyForce();
                break;
        }
        Debug.Log("Грязи " + _countOfMuck);
        Debug.Log("Пыли " + _countOfDusk);
    }
    
    public void NotifyAboutCleaning(Dirty dirty)
    {
        switch (dirty)
        {
            case Dusk dusk:
                _countOfDusk -= dusk.GetDirtyForce();
                break;
            case Muck muck:
                _countOfMuck -= muck.GetDirtyForce();
                break;
            case Puddle puddle:
                _countOfPuddle -= puddle.GetDirtyForce();
                break;
        }
        Debug.Log("Грязи осталось" + _countOfMuck);
        Debug.Log("Пыли осталось" + _countOfDusk);
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
            DontDestroyOnLoad(gameObject); // Сохраняет объект при загрузке новой сцены
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