using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCanvas : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI kills;
    public TextMeshProUGUI timer;


    void Start()
    {
        coins.text = "Coins " + GameData.Instance.coins.ToString();
        kills.text = "Kills " + GameData.Instance.kills.ToString();
        timer.text = "Timer " + GameData.Instance.time.ToString();
    }

    
}
