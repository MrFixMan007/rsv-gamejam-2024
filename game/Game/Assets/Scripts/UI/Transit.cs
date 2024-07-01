using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transit : MonoBehaviour
{
    IEnumerator Load()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
