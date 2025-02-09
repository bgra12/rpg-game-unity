using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("moveX");
    private readonly int moveY = Animator.StringToHash("moveY");
    private readonly int isMoving = Animator.StringToHash("isMoving");
    private readonly int dead = Animator.StringToHash("dead");

    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    public void setIsMoving(bool value) 
    {
        animator.SetBool(isMoving, value);
    }

    public void setMoveDirection(Vector2 dir)
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }
}
