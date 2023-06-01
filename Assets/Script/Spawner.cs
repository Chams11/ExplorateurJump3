using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;

    void Start()
    {
        SelectObject();    
    }

    public void SelectObject()
    {
        float rnd = Random.Range(0f, 1f);
        if (rnd < 0.5f)
        {
            Instantiate(objects[0], transform.position, Quaternion.identity);

        }
        else if (rnd >= 0.5f && rnd < 0.8f)
        {
            Instantiate(objects[1], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(objects[2], transform.position, Quaternion.identity);
        }
    }
}
