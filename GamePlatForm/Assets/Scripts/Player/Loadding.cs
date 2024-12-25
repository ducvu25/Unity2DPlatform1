using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Loadding : MonoBehaviour
{
    public static Loadding instance;

    bool isStartGame = true;
    Data dataGame;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isStartGame)
        {
            isStartGame = false;
            LoadData();
        }
    }
    public void LoadData()
    {
        PlayerPrefs.SetInt("Audio", 1);
        PlayerPrefs.SetFloat("Index_Sound_Bg", 0);
        string path = Path.Combine(Application.persistentDataPath, "data.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            dataGame = JsonUtility.FromJson<Data>(json);
            Debug.Log("Data Loaded: " + json);
        }
        else
        {
            Debug.LogWarning("Data file not found at " + path);
            // You may want to initialize dataGame with default values here
            dataGame = new Data { values = new List<int>() };
            dataGame.values.Add(0);
            for(int i=0; i<15; i++)
            {
                dataGame.values.Add(-1);
            }
            SaveData();
        }
    }

    void SaveData()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.json");
        string json = JsonUtility.ToJson(dataGame, true);
        File.WriteAllText(path, json);
        Debug.Log("Data Saved: " + json);
    }
    public int GetSize()
    {
        return dataGame.values.Count;
    }
    public int GetValue(int i)
    {
        return dataGame.values[i];
    }
    public void OpenMap(int i, int value)
    {
        if (dataGame.values[i] < value)
        {
            dataGame.values[i] = value;
        }
        if (i < GetSize() - 1 && dataGame.values[i + 1] == -1)
        {
            dataGame.values[i + 1] = 0;
        }
        SaveData();
    }
}
[System.Serializable]
public class Data
{
    public List<int> values;
}
