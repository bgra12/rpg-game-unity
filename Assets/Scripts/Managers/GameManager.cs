using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.resetPlayer();
        }
    }

    public void addPlayerExp(float expAmount)
    {
        PlayerExperienceController playerExpController = player.GetComponent<PlayerExperienceController>();
        playerExpController.increasePlayerExperience(expAmount);
    }
}