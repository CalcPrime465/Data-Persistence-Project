using System;
using UnityEngine;
using System.IO;

public class StaticManager : MonoBehaviour
{
    public static StaticManager Instance;

    public int bestScore = 0;
    public string playerName = "none";
    public string bestPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}
