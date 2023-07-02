using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject PlayerMenuScreen;
    public GameObject PlayerOverviewScreen;

    private TextMeshProUGUI playerNameTextView;
    private TextMeshProUGUI healthTextView;
    private TextMeshProUGUI pointTextView;
    private GameObject Player;
    private PlayerStats playerStats;

    private bool PlayerMenuOpen;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerStats = Player.GetComponent<PlayerStats>();
        PlayerMenuOpen = false;
        PlayerOverviewScreen.SetActive(true);


        GameObject child1 = PlayerOverviewScreen.transform.GetChild(0).gameObject;
        playerNameTextView = child1.GetComponent<TextMeshProUGUI>();
        GameObject child2 = PlayerOverviewScreen.transform.GetChild(1).gameObject;
        healthTextView = child2.GetComponent<TextMeshProUGUI>();
        GameObject child3 = PlayerOverviewScreen.transform.GetChild(2).gameObject;
        pointTextView = child3.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        pointTextView.text = "Score: " + playerStats.Points;
        healthTextView.text = "HP: " + playerStats.currentHealth + " / " + playerStats.maxHealth;
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                if (!PlayerMenuOpen)
                {
                    PlayerMenuScreen.SetActive(true);
                    PlayerMenuOpen = true;
                }
                else
                {
                    PlayerMenuScreen.SetActive(false);
                    PlayerMenuOpen = false;
                }
            }
        }
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
