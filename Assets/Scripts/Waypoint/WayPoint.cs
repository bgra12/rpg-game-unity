using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private Vector3[] points;

    public Vector3 entityPosition{get; set;}
    public Vector3[] Points => points;
    private bool gameStarted;
    private void Start()
    {
        entityPosition = transform.position;
        gameStarted = true;
    }

    private void OnDrawGizmos()
    {
        if (!gameStarted && transform.hasChanged)
        {
            entityPosition = transform.position;
        }
    }

    public Vector3 getPosition(int pointIndex)
    {
        return entityPosition + points[pointIndex];
    }
}
