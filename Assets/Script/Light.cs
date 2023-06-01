using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    public GameObject directionalLight;
    public GameObject[] lights;
    public Material skyboxMaterial;
    
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            directionalLight.SetActive(false);
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(true);
            }
            if(skyboxMaterial != null)
            {
                RenderSettings.skybox = skyboxMaterial;
            }
        }
    }

}
