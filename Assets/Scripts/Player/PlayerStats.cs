using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Points = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public int attackPower = 10;
    public int defensePower = 5;
    public EventController Event;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        int actualDamage = damage - defensePower;
        if (actualDamage > 0)
        {
            currentHealth -= actualDamage;
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
        Event.GameOver();
    }
}
