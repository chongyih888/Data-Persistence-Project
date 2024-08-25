using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ValueManager : MonoBehaviour
{
    public static ValueManager Instance;

    public string playerName = null;
    public int highScore = 0;
    public string savedPlayerName;

    private void Awake()
    {
      

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
       

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInfo();

    }

    [System.Serializable]
    class SaveData
    {
        public string player;
        public int scoreHigh;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.player = playerName;
        data.scoreHigh = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.player;
            highScore = data.scoreHigh;
            savedPlayerName = data.player;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      
     
}
