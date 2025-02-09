using UnityEditorInternal;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats playerStats;

        public PlayerStats Stats => playerStats;
    }
}