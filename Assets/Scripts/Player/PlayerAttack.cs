using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform[] attackPositions;
    [SerializeField] private PlayerStats playerStats;

    [Header("Melee Attack Config")] 
    [SerializeField] private ParticleSystem slashFX;
    [SerializeField] private float minDistMeleeAttack;
    
    public Weapon currentWeapon { get; set; }
    
    private PlayerActions playerActions;
    private PlayerAnimationController playerAnimationController;
    private EnemyAI enemyTarget;
    private Coroutine attackCoroutine;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;

    private Transform currentAttackPosition;
    private float currentAttackRotation;
    
    private void Awake()
    {
        playerActions = new PlayerActions();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        playerMana = GetComponent<PlayerMana>();
    }

    private void Update()
    {
        getFirePosition();
    }

    private void Start()
    {
        WeaponManager.instance.equipWeapon(initialWeapon);
        playerActions.Attack.ClickAttack.performed += ctx => attack();
    }

    private void getFirePosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;
        switch (moveDirection.x)
        {
            case > 0f:
                currentAttackPosition = attackPositions[1];
                currentAttackRotation = -90f;
                break;
            case < 0f:
                currentAttackPosition = attackPositions[3];
                currentAttackRotation = -270f;
                break;
        }
        switch (moveDirection.y)
        {
            case > 0f:
                currentAttackPosition = attackPositions[0];
                currentAttackRotation = 0f;
                break;
            case < 0f:
                currentAttackPosition = attackPositions[2];
                currentAttackRotation = 180f;
                break;
        }
    }

    private void attack()
    {
        if(enemyTarget == null) return;

        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = StartCoroutine(attackIEnumerator());
    }

    private IEnumerator attackIEnumerator()
    {
        if (currentAttackPosition ==null) yield break;
        if (currentWeapon.weaponType == WeaponType.Magic)
        {
            if (playerMana.currentMana < currentWeapon.projectileMana) yield break;
            magicAttack();
        }
        else
        {
            meleeAttack();
        }
        
        playerAnimationController.setIsAttacking(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimationController.setIsAttacking(false);
    }

    private void magicAttack()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        Projectile projectile = Instantiate(currentWeapon.projectile, currentAttackPosition.position, rotation);
        projectile.direction = Vector3.up;
        projectile.damage = calculateAttackDamage();
        playerMana.useMana(currentWeapon.projectileMana);
    }
    private void meleeAttack()
    {
        slashFX.transform.position = currentAttackPosition.position;
        slashFX.Play();
        float currentDistToEnemy = Vector3.Distance(enemyTarget.transform.position, transform.position);
        if (currentDistToEnemy <= minDistMeleeAttack)
        {
            enemyTarget.GetComponent<IDamageable>().TakeDamage(calculateAttackDamage());
        }
    }

    private void OnEnable()
    {
        playerActions.Enable();
        SelectionManager.onEnemySelectEvent += enemySelectedCallback;
        SelectionManager.onNoSelectionEvent += noEnemySelectedCallback;
        EnemyHealth.onEnemyDeadEvent += noEnemySelectedCallback;
    }

    private void OnDisable()
    {
        playerActions.Disable();
        SelectionManager.onEnemySelectEvent -= enemySelectedCallback;
        SelectionManager.onNoSelectionEvent -= noEnemySelectedCallback;
        EnemyHealth.onEnemyDeadEvent -= noEnemySelectedCallback;
    }

    private void enemySelectedCallback(EnemyAI selectedEnemy)
    {
        enemyTarget = selectedEnemy;
    }

    private void noEnemySelectedCallback()
    {
        enemyTarget = null;
    }

    private float calculateAttackDamage()
    {
        float damage = playerStats.baseDamage;
        damage += currentWeapon.damage;
        float randomNumber = Random.Range(0f, 100f);
        if (randomNumber <= playerStats.criticalChanceRate)
        {
            damage += damage * (playerStats.criticalDamageRate / 100f);
        }
        return damage;
    }

    public void equipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
        playerStats.totalDamage = playerStats.baseDamage + currentWeapon.damage;
    }
    
}
