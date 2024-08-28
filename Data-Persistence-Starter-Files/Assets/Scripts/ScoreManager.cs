using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int highscore = 0;
    public string highscoreName;
    public string playerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log(Application.persistentDataPath);
        LoadScore();
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
            highscoreName = data.name;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.name = highscoreName;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string name = "";
    }
}
