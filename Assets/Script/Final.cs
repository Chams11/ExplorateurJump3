using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public Timer timer;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameData.Instance.time = timer.currentTime;
            SceneManager.LoadScene("FinalScene");
        }
    }
}
