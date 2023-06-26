using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int attackPower = 10;
    public int defensePower = 5;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        int actualDamage = damage - defensePower;
        if (actualDamage > 0)
        {
            currentHealth -= actualDamage;
            Debug.Log("Player took " + actualDamage + " damage. Current health: " + currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        else
        {
            Debug.Log("Player's defense blocked the attack.");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int enemyDamage = 20;
            TakeDamage(enemyDamage);
        }
    }
    private void Die()
    {
        Debug.Log("Player died!");
    }
}
