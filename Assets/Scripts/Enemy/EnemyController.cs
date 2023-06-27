using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class EnemyController : MonoBehaviour
{
    private GameObject Player;
    private PlayerStats playerStats;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerStats = Player.GetComponent<PlayerStats>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerStats.Points += 5;
        }
    }
}
