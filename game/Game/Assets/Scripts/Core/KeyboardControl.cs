using UnityEngine;

public class KeyboardControl : MonoBehaviour
{
    private GameObject _playerObj;
    private Player _player;

    private void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _player = _playerObj.GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.Interact();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _player.DiscardItem
            (
                new Vector3(_playerObj.transform.position.x - 0.06f,
                    _playerObj.transform.position.y,
                    _playerObj.transform.position.z)
            );
        }
    }
}