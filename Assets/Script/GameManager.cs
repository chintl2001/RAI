using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class GameManager : MonoBehaviour, IDataPresistent
{
    public Text goldText;
    private int gold { get; set; }

    public Text droneText;
    private int drone = 3;

    public Text raiText;
    private int rai;

    private HighScore highScore;

    private HighScoreList _highScoreList;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public HighScoreList GetHighScoreList()
    {
        return _highScoreList;
    }

    public void SetHighScoreList(HighScoreList highScoreList)
    {
        _highScoreList = highScoreList;
    }

    private void Start()
    {
        droneText.text = drone.ToString();
        goldText.text = gold.ToString();
        raiText.text = rai.ToString();
        LoadHighScoreList();
    }

    public void IncreaseGold()
    {
        gold++;
        goldText.text = gold.ToString();
    }
    public void IncreaseGold5()
    {
        gold +=5;
        goldText.text = gold.ToString();
    }
    public void DecreaseGold()
    {
        gold -= 30;
        goldText.text = gold.ToString();
    }

    public void DecreaseDrone()
    {
        drone--;
        droneText.text = drone.ToString();
        if (drone <= 0)
        {
            if (_highScoreList.highScores.Any())
            {
                int maxScore = _highScoreList.highScores.Max(hs => hs.score);
                if (rai > maxScore)
                {
                    string playerName = GenerateRandomName();
                    HighScore newHighScore = new HighScore(playerName, rai);
                    _highScoreList.highScores.Add(newHighScore);
                    SaveHighScoreList();
                }
            }
            else
            {
                string playerName = GenerateRandomName();
                HighScore newHighScore = new HighScore(playerName, rai);
                _highScoreList.highScores.Add(newHighScore);
                SaveHighScoreList();
            }

            SceneManager.LoadScene("GameOver");
        }
    }


    public void IncreaseRai()
    {
        rai++;
        raiText.text = rai.ToString();
    }

    public void IncreaseScore()
    {
        drone++;
        droneText.text = drone.ToString();
    }

    public void LoadData(GameData data)
    {
        this.gold = data.gold;
        this.drone = data.hp;
        this.rai = data.enemyScore;
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
        data.hp = this.drone;
        data.enemyScore = this.rai;
    }

    private void LoadHighScoreList()
    {
        if (File.Exists(GetHighScoreFilePath()))
        {
            string json = File.ReadAllText(GetHighScoreFilePath());
            _highScoreList = JsonUtility.FromJson<HighScoreList>(json);
        }
        else
        {
            _highScoreList = new HighScoreList();
        }
    }

    private void SaveHighScoreList()
    {
        string json = JsonUtility.ToJson(_highScoreList);
        File.WriteAllText(GetHighScoreFilePath(), json);
    }

    private string GetHighScoreFilePath()
    {
        return Application.persistentDataPath + "/highscore.json";
    }

    private string GenerateRandomName()
    {
        int nameLength = 6; // Độ dài của tên ngẫu nhiên
        string allowedCharacters = "abcdefghijklmnopqrstuvwxyz0123456789"; // Các ký tự cho phép trong tên ngẫu nhiên
        System.Random random = new System.Random();

        StringBuilder stringBuilder = new StringBuilder(nameLength);
        for (int i = 0; i < nameLength; i++)
        {
            stringBuilder.Append(allowedCharacters[random.Next(0, allowedCharacters.Length)]);
        }

        return stringBuilder.ToString();
    }
}
