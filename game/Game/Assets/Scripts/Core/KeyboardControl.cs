using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{
    private GameObject playerObj = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Player>().Interact();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            GetComponent<Player>().Discard(new Vector3(playerObj.transform.position.x + 0.02f, playerObj.transform.position.y));
        }
    }
}
