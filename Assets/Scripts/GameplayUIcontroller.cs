using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        //SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
