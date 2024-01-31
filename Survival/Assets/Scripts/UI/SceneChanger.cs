using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OverMenu()
    {
        SceneManager.LoadScene("OverMenu");

    }

}
