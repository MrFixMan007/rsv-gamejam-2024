using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject prefabItemVacuumCleaner; 

    public bool isGamePaused;

    public void SpawnPickablePrefab(Pickable item, Vector3 newItemCoordinates)
    {
        switch (item)
        {
            case ItemVacuumCleaner:
                Instantiate(prefabItemVacuumCleaner, newItemCoordinates, Quaternion.identity);
                break;
        }
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}