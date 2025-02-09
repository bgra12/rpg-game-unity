using UnityEngine;


    public class PlayerExperienceController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats stats;

        public void increasePlayerExperience(float amount)
        {
            stats.currentExp += amount;
            while (stats.currentExp >= stats.nextLevelExp)
            {
                stats.currentExp -= stats.nextLevelExp;
                nextLevel();
            }
        }

        private void nextLevel()
        {
            stats.level++;
            float currentExpRequired = stats.nextLevelExp;
            float newNextLevelExp = Mathf.Round(currentExpRequired + stats.nextLevelExp * (stats.expMultiplier / 100f));
            stats.nextLevelExp = newNextLevelExp;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                increasePlayerExperience(300f);
            }
        }
    }
