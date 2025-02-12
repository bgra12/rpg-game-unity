using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Bars")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image expBar;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI levelTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;

    [Header("Stat Panel")]
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private TextMeshProUGUI statLevelTMP;
    [SerializeField] private TextMeshProUGUI statDamageTMP;
    [SerializeField] private TextMeshProUGUI statCritChanceTMP;
    [SerializeField] private TextMeshProUGUI statCritDamageTMP;
    [SerializeField] private TextMeshProUGUI statTotalExpTMP;
    [SerializeField] private TextMeshProUGUI statCurrentExpTMP;
    [SerializeField] private TextMeshProUGUI statReqExpTMP;
    private void Update()
    {
        updatePlayerUI();
    }

    public void openCloseStatPanel()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
        if (statsPanel.activeSelf)
        {
            updateStatsPanel();
        }
    }

    private void updatePlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, stats.health / stats.maxHealth, 10f * Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, stats.mana / stats.maxMana, 10f * Time.deltaTime);  
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, stats.currentExp / stats.nextLevelExp, 10f * Time.deltaTime);
        
        levelTMP.text = $"Level: {stats.level}";
        healthTMP.text = $"{stats.health} / {stats.maxHealth}";
        manaTMP.text = $"{stats.mana} / {stats.maxMana}";
        expTMP.text = $"{stats.currentExp} / {stats.nextLevelExp}";
    }

    private void updateStatsPanel()
    {
        statLevelTMP.text = stats.level.ToString();
        statDamageTMP.text = stats.totalDamage.ToString();
        statCritChanceTMP.text = stats.criticalChanceRate.ToString();
        statCritDamageTMP.text = stats.criticalDamageRate.ToString();
        statTotalExpTMP.text = stats.totalExp.ToString();
        statCurrentExpTMP.text = stats.currentExp.ToString();
        statReqExpTMP.text = stats.nextLevelExp.ToString();
    }
}
