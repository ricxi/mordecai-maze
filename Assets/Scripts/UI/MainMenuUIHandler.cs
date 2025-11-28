using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private string StartSceneName = "StartScene";
    [SerializeField] private string ControlsSceneName = "ControlsScene";

    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene(StartSceneName);
    }

    public void OnControlsButtonClicked()
    {
        SceneManager.LoadScene(ControlsSceneName);
    }

    public void OnQuitGameButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
