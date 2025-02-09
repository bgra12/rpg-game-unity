using System;
using UnityEngine;


    public class GameManager : MonoBehaviour
    {
      [SerializeField] private PlayerController player;

      private void Update()
      {
          if (Input.GetKeyDown(KeyCode.R))
          {
              player.resetPlayer();
          }
      }
    }
