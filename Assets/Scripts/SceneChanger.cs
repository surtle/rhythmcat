using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void changeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
