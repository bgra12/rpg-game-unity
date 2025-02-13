using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerController player;
    public PlayerController Player => player;
        
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.resetPlayer();
        }
    }

    public void addPlayerExp(float expAmount)
    {
        player.GetComponent<PlayerExperienceController>().increasePlayerExperience(expAmount);
    }
}