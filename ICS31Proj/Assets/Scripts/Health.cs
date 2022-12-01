using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Animator anime;
    
    public float getStartHP()
    {
        return startingHealth;
    }
    public float currentHealth { get; private set; }
    private bool dead;


    private void Awake()
    {
        currentHealth = startingHealth;
        anime = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anime.SetTrigger("Hurt");
        }
        else 
        {
            if (!dead)
            {
                Die();
            }
        }
    }

    public void AddHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, startingHealth);
    }

    private void Die()
    {
        anime.SetTrigger("Die");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        dead = true;
    }
    
    
}
