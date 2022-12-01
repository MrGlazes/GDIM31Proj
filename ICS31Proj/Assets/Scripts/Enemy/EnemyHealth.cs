using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator anime;
    [SerializeField] private float startingHealth;
    private float currentHealth;


    private void Awake()
    {
        currentHealth = startingHealth;
        anime = GetComponent<Animator>();
    }

    /*  
      private void Update()
      {
          if (Input.GetKeyDown(KeyCode.E))
          {
              TakeDamage(1);
          }
      }*/

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //hurt (play hurt anim
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Ahh Im dead");
        anime.SetTrigger("Death");
        
        GetComponent<MeleeEnemy>().enabled = false;
        GetComponentInParent<EnemyPatrol>().enabled = false;
    }
}

