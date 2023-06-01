using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startTime = 300f;

    public TextMeshProUGUI txt;


    public void Start()
    {
        currentTime = startTime;
        txt.color = Color.green;
    }

    
    public void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        txt.text = currentTime.ToString("0");

        

        if(currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

/*    
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            startTime = false;
        }
    }
*/
}
