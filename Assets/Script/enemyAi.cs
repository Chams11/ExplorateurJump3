using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour 
{
    private float Distance;   
    public Transform Target;
    public float chaseRange = 10;
    public float attackRange = 2.2f;
    public float attackRepeatTime = 1;
    private float attackTime;
    public float TheDammage;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animation animations;
    public float enemyHealth;
    private bool isDead = false;
    public int damageOnCollision = 10;



    void Start () 
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
    }



    void Update () 
    {

        if (!isDead)
        {

            
            Target = GameObject.Find("Player").transform;

            
            Distance = Vector3.Distance(Target.position, transform.position);

            // Quand l'ennemi est loin = idle
            if (Distance > chaseRange)
            {
                idle();
            }

            // Quand l'ennemi est proche mais pas assez pour attaquer
            if (Distance < chaseRange && Distance > attackRange)
            {
                chase();
            }

            // Quand l'ennemi est assez proche pour attaquer
            if (Distance < attackRange)
            {
                attack();
            }

        }
    }

    // poursuite
    void chase()
    {
        animations.Play("walk");
        agent.destination = Target.position;
    }

    // Combat
    void attack()
    {
        
        agent.destination = transform.position;

        
        if (Time.time > attackTime) 
        {
            animations.Play("hit");
            Debug.Log("L'ennemi a envoyé " + TheDammage + " points de dégâts");
            attackTime = Time.time + attackRepeatTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(GetComponent<Collider>().transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
   
    void idle()
    {
        animations.Play("idle");
    }

    public void ApplyDammage(float TheDammage)
    {
        if (!isDead)
        {
            enemyHealth = enemyHealth - TheDammage;
            print(gameObject.name + "a subit " + TheDammage + " points de dégâts.");

            if(enemyHealth <= 0)
            {
                Dead();
            }
        }
    }

    public void Dead()
    {
        isDead = true;
        animations.Play("die");
        Destroy(transform.gameObject, 5);
    }

    public void OnCollisionEnter()
    {

    }
}