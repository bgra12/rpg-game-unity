using UnityEngine;

    public class PlayerMana : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats stats;


        public void useMana(float amount)
        {
            stats.mana = Mathf.Max(stats.mana -= amount, 0f);
           
        }
    }
