using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string highscoreName;
    public int highscore;
    public int currentScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighscore();
        }
    }
    
    public void LoadHighscore()
    {
        Debug.Log("LoadHighscore called");
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            Highscorer best = JsonUtility.FromJson<Highscorer>(data);
            highscore = best.highscores;
            highscoreName = best.name;
        }
        else
        {
            highscore = 0;
            highscoreName = "Player";
        }
    }

    public void SaveHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (playerName != null && currentScore > highscore)
        {
            Highscorer newBest = new Highscorer();
            newBest.name = playerName;
            newBest.highscores = currentScore;
            string data = JsonUtility.ToJson(newBest);
            File.WriteAllText(path, data);
            highscoreName = playerName;
            highscore = currentScore;
        }
    }

    [System.Serializable]
    public class Highscorer
    {
        public string name;
        public int highscores;
    }
}
