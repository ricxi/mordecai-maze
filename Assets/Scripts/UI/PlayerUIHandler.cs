using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private TMP_Text hintText;
    [SerializeField] private TMP_Text locationText;
    [SerializeField] private float locationTextDuration = 5.0f;

    private bool isPaused = false;

    private void Start()
    {
        hintPanel.SetActive(false);
        hintText.text = "";
        string sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(DisplayLocationText(sceneName));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            hintPanel.SetActive(true);
            Time.timeScale = isPaused ? 0 : 1;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            isPaused = false;
            hintPanel.SetActive(false);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }

    public void DisplayHintText(string text)
    {
        hintText.text = text;
        isPaused = true;
        hintPanel.SetActive(true);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public IEnumerator DisplayLocationText(string text)
    {
        locationText.text = text;
        yield return new WaitForSeconds(locationTextDuration);
        locationText.text = "";
    }

    public void OnClickOK()
    {
        if (isPaused)
        {
            hintText.text = "";
            isPaused = false;
            hintPanel.SetActive(false);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}

// public IEnumerator DisplayAndRemoveText(string textToDisplay, float lifetime)
// {
//     hintText.text = textToDisplay;
//     yield return new WaitForSeconds(5);
//     hintText.text = "";
// }