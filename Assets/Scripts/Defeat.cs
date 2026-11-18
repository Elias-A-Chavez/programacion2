using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
   

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
