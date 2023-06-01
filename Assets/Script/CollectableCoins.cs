using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableCoins : MonoBehaviour
{

    public int coins;
    private SimpleCollectibleScript simpleCo;
    public TextMeshProUGUI txt;


    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Coins")
        {
            simpleCo = Col.gameObject.GetComponent<SimpleCollectibleScript>();
            switch(simpleCo.CollectibleType)
            {
                case SimpleCollectibleScript.CollectibleTypes.Copper:
                    coins += 1;
                    break;

                case SimpleCollectibleScript.CollectibleTypes.Silver:
                    coins += 5;
                    break;

                case SimpleCollectibleScript.CollectibleTypes.Gold:
                    coins += 10;
                    break;
            }
            Debug.Log("Coin Collected!");
            GameData.Instance.coins = coins;
            Destroy(Col.gameObject);
            UpdateText();
        }
    }

    public void UpdateText()
    {
        txt.text = coins.ToString();
    }
}
