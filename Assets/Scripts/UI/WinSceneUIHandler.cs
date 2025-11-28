using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneUIHandler : MonoBehaviour
{

    [SerializeField] private string MainMenuSceneName = "MainMenu";
    [SerializeField] private string StartSceneName = "StartScene";

    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene(StartSceneName);
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void OnQuitGameButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

}
