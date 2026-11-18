using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
   

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
