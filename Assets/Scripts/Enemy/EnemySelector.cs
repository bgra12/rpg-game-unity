using System;
using UnityEngine;


public class EnemySelector : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject selectorSprite;

    private EnemyAI enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
    }

    private void OnEnable()
    {
        SelectionManager.onEnemySelectEvent += enemySelectedCallBack;
        SelectionManager.onNoSelectionEvent += noSelectionCallBack;
    }

    private void OnDisable()
    {
        SelectionManager.onEnemySelectEvent -= enemySelectedCallBack;
        SelectionManager.onNoSelectionEvent -= noSelectionCallBack;
    }

    private void enemySelectedCallBack(EnemyAI selectedEnemy)
    {
        if (selectedEnemy == enemy)
        {
            selectorSprite.SetActive(true);
        }
        else
        {
            selectorSprite.SetActive(false);
        }
    }

    public void noSelectionCallBack()
    {
        selectorSprite.SetActive(false);
    }
}