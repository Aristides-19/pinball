using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pinball");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
