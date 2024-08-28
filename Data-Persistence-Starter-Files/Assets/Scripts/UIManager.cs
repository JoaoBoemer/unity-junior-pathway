using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI highscoreText;
    void Start()
    {
        if(ScoreManager.Instance != null && ScoreManager.Instance.highscoreName != null)
            highscoreText.text = "Highscore: " + ScoreManager.Instance.highscoreName + " : " + ScoreManager.Instance.highscore;
    }

    public void StartGame()
    {
        ScoreManager.Instance.playerName = playerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
