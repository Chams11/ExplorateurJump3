using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemiesKilled : MonoBehaviour
{

    public static EnemiesKilled instance;

    public TextMeshProUGUI enemieKilled;

    int enemie = 0;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        enemieKilled.text = enemie.ToString() + " Kill";
    }

    
    public void AddEnemiesKilled()
    {
        enemie += 1;
        GameData.Instance.kills = enemie;
        enemieKilled.text = enemie.ToString() + " Kill";
    }
}
