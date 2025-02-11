using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : FSMAction
{
    [Header("Config")]
    [SerializeField] private float speed;

    private WayPoint wayPoint;
    private int wayPointIndex;
    private Vector3 nextPosition;

    private void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }

    public override void act()
    {
       followPath();
    }

    private void followPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, getCurrentPosition(), speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, getCurrentPosition()) < 0.1f)
        {
            updateNextPosition();
        }
    }

    private void updateNextPosition()
    {
        wayPointIndex++;
        if (wayPointIndex > wayPoint.Points.Length - 1)
        {
            wayPointIndex = 0;
        }
       
    }

    private Vector3 getCurrentPosition()
    {
        return wayPoint.getPosition(wayPointIndex);
    }
    
    
}
