using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject UIScreen;
    public TextMeshProUGUI pointTextView;
    public TextMeshProUGUI healthTextView;
    private GameObject Player;
    private PlayerStats playerStats;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerStats = Player.GetComponent<PlayerStats>();
        UIScreen.SetActive(true);
    }

 
    void Update()
    {
        pointTextView.text = "Score: " + playerStats.Points;
        healthTextView.text = "HP: " + playerStats.currentHealth + " / " + playerStats.maxHealth;
    }
    public void GameOver() 
    {
        gameOverScreen.SetActive(true);
    }
}
