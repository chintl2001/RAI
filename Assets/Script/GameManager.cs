using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text goldText;
    private int gold;

    public Text droneText;
    private int drone;

    public void IncreaseGold()
    {
        gold++;
        goldText.text = gold.ToString();
    }

    public void DecreaseDrone()
    {
        drone--;
        droneText.text = drone.ToString();
    }
}

