using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUIHandler : MonoBehaviour
{
    [SerializeField] private string NextSceneName = "Lobby";

    public void OnNextButtonClicked()
    {
        SceneManager.LoadScene(NextSceneName);
    }


}
