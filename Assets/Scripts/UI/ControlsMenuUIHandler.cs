using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenuUIHandler : MonoBehaviour
{
    [SerializeField] private string StartSceneName = "StartScene";
    [SerializeField] private string BackToSceneName = "MainMenu";

    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene(StartSceneName);
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene(BackToSceneName);
    }
}
