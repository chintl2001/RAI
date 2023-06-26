using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IDataPresistent
{
    public Text goldText;
    private int gold;

    public Text droneText;
    private int drone = 3;

    public Text raiText;
    private int rai;

    private void Start()
    {
        droneText.text = drone.ToString();
    }
    public void IncreaseGold()
    {
        gold++;
        goldText.text = gold.ToString();
    }
    
    public void DecreaseDrone()
    {
        drone--;
        droneText.text = drone.ToString();
        if (drone <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void IncreaseRai()
    {
        rai++;
        raiText.text = rai.ToString();
    }

    public void LoadData(GameData data)
    {
        this.gold = data.gold;
       // this.drone = data.hp;
        this.rai = data.enemyScore;
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
      //  data.hp = this.drone;
        data.enemyScore = this.rai;
    }
}

