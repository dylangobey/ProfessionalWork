using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private GameObject progressPanel; // Fetches the GameObject "progressPanel"
    [SerializeField] private Slider progressBar; // Fetches the Slider "progressBar"
    [SerializeField] private Text progressValue; // Fetches the Text "progressValue"

    public void Awake()
    {
        progressPanel.SetActive(false); // Sets the progressPanel to "false" so it is not shown in-game
    }

    public void LoadLevel(string levelName)
    {
        progressPanel.SetActive(true); // Sets the progressPanel to "true" so it is shown in-game
        StartCoroutine(LoadLevelAsync(levelName)); // Loads the level
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName); // Ensures level is loaded then the following occurs

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress); // Gets the progress of the game loading

            progressBar.value = progress; 
            progressValue.text = (progress * 100f).ToString("F0") + "%"; // Updates the text in the loading scene up to the "99%" point

            //Debug.Log(progress);

            yield return null;
        }
    }
}
