using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private PlayerController player;
    private PlayerExperienceController playerExpController;
    private void Awake()
    {
        playerExpController = player.GetComponent<PlayerExperienceController>();
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
        playerExpController.increasePlayerExperience(expAmount);
    }
}