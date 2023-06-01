using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFaible : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            EnemiesKilled.instance.AddEnemiesKilled();
        }
    }
}
